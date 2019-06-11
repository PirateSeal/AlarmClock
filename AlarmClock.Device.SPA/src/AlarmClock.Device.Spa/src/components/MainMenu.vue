/*
 * File: MainMenu.vue                                                          *
 * Project: alarmclock                                                         *
 * File Created: Wednesday,3rd June 2019 01:56:58 pm                           *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 6th June 2019 9:57:37 am                           *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

<template>
  <div class="clock_preset">
    <div class="title">{{clock.title}}</div>
    <div class="time-container">
      <div class="time" v-for="(time, index) in getTime(clock.time)" :key="time + index">{{time}}</div>
    </div>
    <div class="days-container">
      <div
        class="day"
        v-for="(day, index) in days()"
        :key="day.key"
        :class="{ active: isDayActive(clock, index)}"
      >{{formatDay(day)[0]}}</div>
    </div>
  </div>
</template>

<script>
import { getPresetList } from "../api/clockApi";

export default {
  data() {
    return {
      PresetList: []
    };
  },
  async mounted() {
    this.PresetList = await getPresetList();
  }
};
</script>
