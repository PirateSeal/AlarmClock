/*
 * File: MainMenu.vue                                                          *
 * Project: alarmclock                                                         *
 * File Created: Wednesday,3rd June 2019 01:56:58 pm                           *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Tuesday, 11th June 2019 12:18:11 pm                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

<template>
  <div class="clock_preset">
    <div class="Presets"></div>
    <div class="text" @click="Home">
      <h1 class="link">Go to Clock</h1>
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
  },
  methods: {
    Home() {
      this.$router.replace("/");
    }
  }
};
</script>
