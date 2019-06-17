/*
 * File: index.vue                                                             *
 * Project: alarm-clock                                                        *
 * File Created: Thursday,4th May 2019 09:07:47 am                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Tuesday, 11th June 2019 3:19:17 pm                           *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

<template>
  <div class="clock_preset" @click="$router.push('/EditPreset/'+$route.params.id+'/'+index)">
    <div class="title">{{preset.presetName}}</div>
    <div class="time-container">
      <div
        class="time"
        v-for="(wakingTime, index) in getTime(preset.wakingTime)"
        :key="wakingTime + index"
      >{{wakingTime}}</div>
    </div>
    <div class="days-container">
      <!-- <div
        class="day"
        v-for="(day, index) in days()"
        :key="day.key"
        :class="{ active: isDayActive(clock, index)}"
      >{{formatDay(day)[0]}}</div>-->
    </div>
  </div>
</template>

<script>
import days from "@/components/enums/days";
import { deleteClockAsync } from "@/api/clockApi";
import { mapGetters } from "vuex";
import { formatActivationFlag } from "@/api/formatActivationFlag";

export default {
  name: "clock_preset",
  props: {
    preset: {
      type: Object,
      required: true
    }
  },
  mounted() {
    console.log(formatActivationFlag(this.preset.activationFlag));
  },
  data() {
    return {};
  },

  methods: {
    days() {
      return days;
    },
    getTime(time) {
      return time.split("").splice(0, 5);
    },
    formatDay(day) {
      return Object.keys(day)[0];
    },
    isDayActive(clock, index) {
      return clock.days.find(e => e === index + 1);
    }
  }
};
</script>
<style lang="scss" scoped>
.clock_preset {
  min-height: 256px;
  height: 256px;
  min-width: 256px;
  max-width: 512px;
  flex-grow: 1;
  margin-left: 1%;
  margin-right: 1%;

  background: rgb(1, 1, 133);
  display: flex;
  align-items: center;
  justify-content: flex-start;
  flex-direction: column;
  overflow: hidden;
  transition: all 0.5s;
  border-radius: 25px 25px 25px 25px;
  box-shadow: 0px -1px 30px 0px rgba(0, 0, 0, 0.9);
  &:hover {
    cursor: pointer;
    background: rgba(0, 0, 177, 0.644);
    transform: scale(1.2);
  }
  .title {
    height: 30%;
    color: white;
    font-size: 50px;
    font-family: "Lucida Sans", "Lucida Sans Regular", "Lucida Grande",
      "Lucida Sans Unicode", Geneva, Verdana, sans-serif;
  }
  .time-container {
    height: 60%;
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: row;

    .time {
      display: flex;
      align-items: center;
      justify-content: center;
      font-size: 48px;
      width: 48px;
      height: 72px;
      margin: 0 4px;
      padding: 4px;
      font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen,
        Ubuntu, Cantarell, "Open Sans", "Helvetica Neue", sans-serif;
      &:nth-child(1n) {
        background: rgba(207, 207, 207, 0.835);
        color: rgb(0, 0, 0);
        border-radius: 2px;
      }
      &:nth-child(3n) {
        width: 20px;
        background: none;
        color: gray;
      }
    }
  }
  .days-container {
    height: 10%;
    display: flex;
    justify-content: space-between;
    width: 80%;
    .day {
      margin: 0% 0%;
      background-color: rgba(226, 226, 226, 0.938);
      border-radius: 50%;
      width: 24px;
      height: 24px;
      display: flex;
      align-items: center;
      justify-content: center;

      &.active {
        border: 1px solid red;
        background-color: plum;
      }
    }
  }
}
</style>
