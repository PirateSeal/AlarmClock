<template>
  <form @submit="onSubmit($event)">
    <div class="box-horizon">
      <div class="box-vertical">
        <label class="required">Preset Name</label>
        <input type="text" v-model="preset.PresetName" required>

        <label class="required">Waking Time</label>
        <input type="time" v-model="preset.WakingTime" required>

        <label class="required">Song</label>

        <input type="text" v-model="preset.Song" required>
      </div>

      <label class="required">Activation Flag</label>

      <div class="box-vertical">
        <div class="box-horizon">
          <input type="checkbox" v-model="days[0]" value="1">Activé
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[1]" value="1">Lundi
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[2]" value="1">Mardi
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[3]" value="1">Mercredi
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[4]" value="1">Jeudi
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[5]" value="1">Vendredi
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[6]" value="1">Samedi
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[7]" value="1">Dimanche
        </div>
      </div>

      <div class="box-vertical">
        <label class="required">Challenge</label>

        <select type="select" v-model="preset.Challenge">
          <option value="0">BlindTest</option>
          <option value="1">Joke</option>
          <option value="2">Snake</option>
          <option value="3">Pacman</option>
          <option value="4">Tetris</option>
          <option value="5">Reflex Test</option>
        </select>

        <br>
        <br>

        <label type="text">Alarm Preset Id : {{preset.PresetId}}</label>

        <br>
        <br>

        <label type="text">Clock Id : {{getUserInfo.clocks[$route.params.id].clockId}}</label>
      </div>
    </div>

    <br>
    <br>

    <button type="submit">Sauvegarder</button>
  </form>
</template>

<script>
import {
  createPresetAsync,
 getPresetAsync,
 updatePresetAsync
} from "@/api/presetApi.js";

import { mapGetters } from "vuex";
import Vuex from "vuex";

export default {
  computed: {
    ...mapGetters({
      getUserInfo: "getUserInfo"
    })
  },
  data() {
    return {
      preset: {
        // PresetId: this.$route.params.presetId,
        // PresetName: this.info.clocks[this.$route.params.id].presets[this.$route.params.presetId].presetName,
        // WakingTime: this.info.clocks[this.$route.params.id].presets[this.$route.params.presetId].wakingTime,
        // Song: this.info.clocks[this.$route.params.id].presets[this.$route.params.presetId].song,
        // ActivationFlag: this.info.clocks[this.$route.params.id].presets[this.$route.params.presetId].activationFlag,
        // Challenge: this.info.clocks[this.$route.params.id].presets[this.$route.params.presetId].challenge
      },
      days: [true, false, true, true, false, true, false],
      errors: [],
      info: {}
    };
  },
created(){
  if(this.$route.params.presetId != null) {
    this.preset.PresetId = this.$route.params.presetId;
    this.preset.PresetName      = this.getUserInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId].presetName;
    this.preset.WakingTime      = this.getUserInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId].wakingTime;
    this.preset.Song            = this.getUserInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId].song;
    this.preset.ActivationFlag  = this.getUserInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId].activationFlag;
    this.preset.Challenge       = this.getUserInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId].challenge;
      
    this.challenges = this.getUserInfo.challenges;
  }
},
  async mounted() {
    //this.id = this.$route.params.id;
    if(this.$route.params.presetId != null) {
      this.preset.PresetId = this.$route.params.presetId;
      this.preset.PresetName      = this.getUserInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId].presetName;
      this.preset.WakingTime      = this.getUserInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId].wakingTime;
      this.preset.Song            = this.getUserInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId].song;
      this.preset.ActivationFlag  = this.getUserInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId].activationFlag;
      this.preset.Challenge       = this.getUserInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId].challenge;
      
      this.challenges = this.getUserInfo.challenges;
   }
    

    this.preset.clockId = this.getUserInfo.clocks[this.$route.params.id].clockId 
    console.log(this.preset)
  },

  methods: {

    async onSubmit(event) {
      event.preventDefault();
      var errors = [];

      if (!this.preset.name) errors.push("Name");
      if (!this.preset.wakingTime) errors.push("WakingTime");
      if (!this.preset.song) errors.push("Song");
      // if (!this.preset.activationFlag) errors.push("ActivationFlag");
      if (!this.preset.challenge) errors.push("Challenge");
          debugger;

      this.errors = errors;
      if (errors.length == 0) {
        try {          
          if (this.$route.fullPath.split('/')[1] == "EditPreset") await updatePresetAsync(this.preset);
          else await createPresetAsync(this.preset);
          this.$router.replace("");
        } catch (e) {
          console.error(e);
        }
      }
      this.$router.push('/clock/'+this.$route.params.id+'/Presets')
    }
  }
};
</script>

<style lang="scss">
input[type="text"],
select {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

input[type="select"],
select {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

input[type="checkbox"],
select {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

input[type="submit"] {
  width: 100%;
  background-color: #4caf50;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

input[type="submit"]:hover {
  background-color: #45a049;
}

.box-horizon {
  display: flex;
  input[type="time"],
  select {
    width: 100%;
    padding: 12px 20px;
    margin: 8px 0;
    display: inline-block;
    border: 1px solid #ccc;
    border-radius: 4px;
    box-sizing: border-box;
  }
}

.box-vertical {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(300px, auto));
}
</style>