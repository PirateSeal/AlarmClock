/*
 * File: Home.vue                                                              *
 * Project: alarmclock                                                         *
 * File Created: Tuesday,2nd June 2019 02:22:06 pm                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Tuesday, 11th June 2019 12:24:43 pm                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

<template>
  <section>
    <div class="container">
      <div class="text">
        <h1>Welcome to AlarmClock</h1>
        <h2>This is the {{ClockName}} clock</h2>
      </div>
      <div class="clock">
        <div class="column">
          <div class="num">0</div>
          <div class="num">1</div>
          <div class="num">2</div>
        </div>
        <div class="column">
          <div class="num">0</div>
          <div class="num">1</div>
          <div class="num">2</div>
          <div class="num">3</div>
          <div class="num">4</div>
          <div class="num">5</div>
          <div class="num">6</div>
          <div class="num">7</div>
          <div class="num">8</div>
          <div class="num">9</div>
        </div>
        <div class="colon"></div>
        <div class="column">
          <div class="num">0</div>
          <div class="num">1</div>
          <div class="num">2</div>
          <div class="num">3</div>
          <div class="num">4</div>
          <div class="num">5</div>
        </div>
        <div class="column">
          <div class="num">0</div>
          <div class="num">1</div>
          <div class="num">2</div>
          <div class="num">3</div>
          <div class="num">4</div>
          <div class="num">5</div>
          <div class="num">6</div>
          <div class="num">7</div>
          <div class="num">8</div>
          <div class="num">9</div>
        </div>
        <div class="colon"></div>
        <div class="column">
          <div class="num">0</div>
          <div class="num">1</div>
          <div class="num">2</div>
          <div class="num">3</div>
          <div class="num">4</div>
          <div class="num">5</div>
        </div>
        <div class="column">
          <div class="num">0</div>
          <div class="num">1</div>
          <div class="num">2</div>
          <div class="num">3</div>
          <div class="num">4</div>
          <div class="num">5</div>
          <div class="num">6</div>
          <div class="num">7</div>
          <div class="num">8</div>
          <div class="num">9</div>
        </div>
      </div>
      <div v-if="!this.RingOn"> 
      </div>
      <div v-else>
        <audio controls autoplay style="display:none" id="myAudio" loop>
          <source :src="MusicName + Time" type="audio/mpeg">
        </audio>
        <button @click="Game">Jouer</button>
      </div>
      <div class="text" @click="MainMenu">
        <h1 class="link">Go to Presets</h1>
      </div>
    </div>
  </section>
</template>

<script>
import { runClock } from "../api/clockScript.js";
import { getClockInfo } from "../api/clockApi.js";
import PresetFile from "../../public/presets.json";
import vue from 'vue';

export default {
  data() {
    return {
      ClockName: "",
      RingOn: false,
      MusicName: "",
      Time: "#t=00:00:00",
      EndTime: "",
      ClockTime: "None",
      GameName: "",
      Loop: {},
      PresetList: PresetFile.PresetList
    };
  },
  async mounted() {

    this.ClockName = await getClockInfo();

    let columns = Array.from(document.getElementsByClassName("column"));
    runClock(columns);
    var date;
      this.Loop = window.setInterval(() => {
        date = new Date;
        if (date.getSeconds() == 0) 
        {
          this.ClockUpdate(date);
          console.log(date.getSeconds());
          this.TestClock();
        }
      },1000);
  },
  methods: {

    MainMenu() {

      this.$router.replace("/MainMenu");
    },

    RingBell() {

      this.RingOn = true;
      console.log("test true")
    },

    async TestClock() {

      var d = new Date;
      var n = this.FormatHour(d);

      console.log("Actual hour : " + n);
      console.log("Alarm hour : " + this.ClockTime);
      if(n == this.ClockTime) {
        console.log(true)
        this.RingBell()
      }
      else {
        return false;
      }
    },

    Game() {

      window.clearInterval(this.Loop);
      console.log("Stop Loop");
      this.EndTime = document.getElementById("myAudio").currentTime.toFixed(2);
      if (this.EndTime < 10) {

        this.EndTime = "0" + this.EndTime;
      }
      var temp = this.EndTime.split(".");
      this.EndTime = temp[0];
      this.$router.replace("/" + this.GameName + "/" + this.EndTime);
    },

    ClockUpdate(date) {

      var day = date.getDay();
      for (var i = 0 ; i < this.PresetList.length ; i++) {
        
        if (day == 1 && 
            this.PresetList[i].ActivationFlag.Monday && 
            this.PresetList[i].ActivationFlag.Active) 
        {

          this.AlarmUpdate(date, this.PresetList[i].AlarmTime);
        }
        else if (day == 2 && 
            this.PresetList[i].ActivationFlag.Tuesday && 
            this.PresetList[i].ActivationFlag.Active) 
        {

          this.AlarmUpdate(date, this.PresetList[i].AlarmTime);
        }
        else if (day == 3 && 
            this.PresetList[i].ActivationFlag.Wednesday && 
            this.PresetList[i].ActivationFlag.Active) 
        {

          this.AlarmUpdate(date, this.PresetList[i].AlarmTime);
        }
        else if (day == 4 && 
            this.PresetList[i].ActivationFlag.Thursday && 
            this.PresetList[i].ActivationFlag.Active) 
        {

          this.AlarmUpdate(date, this.PresetList[i].AlarmTime);
        }
        else if (day == 5 && 
            this.PresetList[i].ActivationFlag.Friday && 
            this.PresetList[i].ActivationFlag.Active) 
        {

          this.AlarmUpdate(date, this.PresetList[i].AlarmTime);
        }
        else if (day == 6 && 
            this.PresetList[i].ActivationFlag.Saturday && 
            this.PresetList[i].ActivationFlag.Active) 
        {

          this.AlarmUpdate(date, this.PresetList[i].AlarmTime);
        }
        else if (day == 0 && 
            this.PresetList[i].ActivationFlag.Sunday && 
            this.PresetList[i].ActivationFlag.Active) 
        {

          this.AlarmUpdate(date, this.PresetList[i].AlarmTime);
        }
      }
    },

    AlarmUpdate(date, Alarm) {

      var hour = this.FormatHour(date);
      if (hour < Alarm) {

        if (this.ClockTime == "None" || this.ClockTime > Alarm) {

          this.ClockTime = Alarm;
        }
      }
    },

    FormatHour(date) {

      var formatDate = "";
      if (date.getHours() < 10) 
      {
        formatDate = "0" + date.getHours();
      }
      else 
      {
        formatDate = date.getHours();
      }

      formatDate += ":";

      if (date.getMinutes() < 10) 
      {
        formatDate += "0" + date.getMinutes();
      }
      else 
      {
        formatDate += date.getMinutes();
      }

      formatDate += ":";

      if (date.getSeconds() < 10) 
      {
        formatDate += "0" + date.getSeconds();
      }
      else 
      {
        formatDate += date.getSeconds();
      }

      return formatDate;
    }
  }
};
</script>

<style lang="scss" scoped>
@import url("https://fonts.googleapis.com/css?family=Josefin+Sans&display=swap");

.container {
  text-align: center;
  color: #0e141b;
  font-family: "Josefin Sans";
  font-weight: 300;

  .text {
    font-size: 25px;
    .link {
      text-decoration-line: underline;
    }
  }

  .clock {
    margin-top: -10%;
    max-height: 700px;
    overflow: hidden;

    .column,
    .colon {
      display: inline-block;
      vertical-align: top;
      font-size: 86px;
      line-height: 86px;
    }

    .column {
      transition: -webkit-transform 300ms;
      transition: transform 300ms;
      transition: transform 300ms, -webkit-transform 300ms;
    }

    .colon {
      transition: -webkit-transform 300ms;
      transition: transform 300ms;
      transition: transform 300ms, -webkit-transform 300ms;
      -webkit-transform: translateY(calc(50vh - 43px));
      transform: translateY(calc(50vh - 43px));
    }
    .colon:after {
      content: ":";
    }

    .num {
      transition: opacity 1000ms, text-shadow 100ms;
      opacity: 0;
    }
    .num.visible {
      opacity: 1;
      text-shadow: 1px 1px 0px #336699;
    }
    .num.close {
      opacity: 0.35;
    }
    .num.far {
      opacity: 0;
    }
    .num.distant {
      opacity: 0;
    }
  }
}
</style>
