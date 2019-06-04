<template>
  <section class="jumbotron text-center">
    <div class="container">
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
    </div>
  </section>
</template>




<script>
import {} from "../api/clockScript.js";
export default {};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css?family=Roboto+Condensed:300");
.clock {
  text-align: center;
  background-color: #0e141b;
  color: rgba(224, 230, 235, 0.89);
  font-family: "Roboto", sans-serif;
  font-weight: 300;
  overflow: hidden;
}

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
  transition: opacity 500ms, text-shadow 100ms;
  opacity: 0.025;
}
.num.visible {
  opacity: 1;
  text-shadow: 1px 1px 0px #336699;
}
.num.close {
  opacity: 0.35;
}
.num.far {
  opacity: 0.15;
}
.num.distant {
  opacity: 0.1;
}
</style>
