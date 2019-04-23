<template>
  <div class="clock_preset">
    <div class="title">{{clock.title}}</div>
    <div class="time-container">
      <div class="time" v-for="(time, index) in getTime(clock.time)" :key="time + index">{{time}}</div>
    </div>
    <div class="days-container">
      <div class="day" v-for="(day, index) in days" :key="day.key" :class="{ active: isDayActive(clock, index)}">
        {{formatDay(day)[0]}}
      </div>
    </div>
  </div>
</template>

<script>
import days from '@/components/enums/days'
export default {
  name: "clock_preset",
  props: {
    clock: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
      days
    };
  },
  methods: {
    getTime(time) {
      return time.split("");
    },
    formatDay(day) {
      return Object.keys(day)[0]
    },
    isDayActive(clock, index) {
      return clock.days.find(e => e === index + 1)
    }
  }
};
</script>
<style lang="scss" scoped>
.clock_preset {
  min-height: 256px;
  height: 256px;
  min-width: 128px;
  width: 512px;
  max-width: 512px;
  flex-grow: 1;
  margin: 2.5%;
  background: blue;
  display: flex;
  align-items: center;
  justify-content: flex-start;
  flex-direction: column;
  overflow: hidden;
  transition: all .5s;
  &:hover {
    cursor: pointer;
    background: rgba(0, 0, 255, 0.623);
    transform: scale(1.2);
  }
  .title {
    height: 30%;
    font-size: 50px;
    font-family: "Lucida Sans", "Lucida Sans Regular", "Lucida Grande",
      "Lucida Sans Unicode", Geneva, Verdana, sans-serif;
  }
  .time-container {
    height: 60%;
    display: flex;
    align-items:center;
    justify-content:center;
    flex-direction: row;
    .time {
      display: flex;
      align-items:center;
      justify-content:center;
      font-size: 48px;
      width: 48px;
      height: 72px;
      margin: 0 4px;
      padding: 4px;
      &:nth-child(1n) {
        background: gray;
        color: red;
      }
      &:nth-child(3n) {
        width: 20px;
        background: none;
        color: green;
      }
    };
  }
  .days-container {
    height: 10%;
    display: flex;
    justify-content: space-between;
    width: 80%;
    .day{
    // margin: TOP RIGHT BOTTOM LEFT;
    // margin: TOP&BOTTOM LEFT&RIGHT ;
    // margin: LEFT&RIGHT&TOP&BOTTOM;
    margin: 0% 0%;
    background-color: blanchedalmond;
    border-radius: 50%;
    width: 24px;
    height: 24px;
    display: flex;
    align-items:center;
    justify-content:center;

    &.active{
      border: 1px solid red;
      background-color: plum;
    }
    }
  }
}
</style>
