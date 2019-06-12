/*
 * File: MainMenu.vue                                                          *
 * Project: alarmclock                                                         *
 * File Created: Wednesday,3rd June 2019 01:56:58 pm                           *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Tuesday, 11th June 2019 1:13:02 pm                           *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

<template>
  <div class="container">
    <div class="Presets">
      <div class="presetlist" v-if="PresetList.length !== 0">
        <PresetList v-for="preset in PresetList" :key="preset.presetId" :preset="preset"></PresetList>
      </div>
      <div v-else>Vous n'avez pas de presets</div>
    </div>
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
<style lang="scss" scoped>
.container {
  display: flex;
  flex-direction: column;
  align-content: center;
  .presetlist {
    display: flex;
    flex-direction: row;
    width: 100%;
    flex-wrap: wrap;
  }
}
</style>
