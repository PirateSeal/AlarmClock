<template>
  <section class="jumbotron text-center">
    <div class="container">
      <div class="text">
        <h1>Welcome to AlarmClock</h1>
        <h2>This is the {{this.Name}} clock</h2>
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
      <div class="text" @click="MainMenu">
        <h1 class="link">Go to Presets</h1>
      </div>
    </div>
  </section>
</template>

<script>
import { runClock } from "../api/clockScript.js";
import { getClockName } from "../api/clockApi.js";

export default {
  data() {
    return {
      Name: "Test"
    };
  },
  mounted() {
    this.Name = getClockName();

    let columns = Array.from(document.getElementsByClassName("column"));
    runClock(columns);
  },
  methods: {
    MainMenu() {
      this.$router.replace("/MainMenu");
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
