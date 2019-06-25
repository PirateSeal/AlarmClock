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
          <source :src="Name + Time" type="audio/mpeg">
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
import vue from 'vue';

export default {
  data() {
    return {
      ClockName: "",
      RingOn: false,
      Name: "Pharell Williams - Happy.mp3",
      Time: "#t=00:00:00",
      EndTime: "",
      ClockTime: "",
      Game: "Snake"
    };
  },
  async mounted() {
    this.ClockName = await getClockInfo();

    let columns = Array.from(document.getElementsByClassName("column"));
    runClock(columns);
    var date;
    this.$nextTick(function () {
      window.setInterval(() => {
        date = new Date;
        if (date.getSeconds() == 0) 
        {
          this.ClockTime = "13:44:00";
          console.log(date.getSeconds());
          this.TestClock();
        }
      },1000);
    })
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

      //debugger;
      var d = new Date;
      var n;
      if (d.getHours() < 10) 
      {
        n = "0" + d.getHours();
      }
      else 
      {
        n = d.getHours();
      }

      n = n + ":";

      if (d.getMinutes() < 10) 
      {
        n = n + "0" + d.getMinutes();
      }
      else 
      {
        n = n + d.getMinutes();
      }

      n = n + ":";

      if (d.getSeconds() < 10) 
      {
        n = n + "0" + d.getSeconds();
      }
      else 
      {
        n = n + d.getSeconds();
      }

      console.log(n);
      console.log(this.ClockTime);
      if(n == this.ClockTime) {
        console.log(true)
        this.RingBell()
      }
      else {
        return false;
      }
    },

    Game() {

      this.EndTime = document.getElementById("myAudio").currentTime.toFixed(2);
      if (this.EndTime < 10) {

        this.EndTime = "0" + this.EndTime;
      }
      var temp = this.EndTime.split(".");
      this.EndTime = temp[0];
      this.$router.replace("/" + this.Game + "/" + this.EndTime);
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
