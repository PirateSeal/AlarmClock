<template>
  <form @submit="onSubmit($event)">
    <div class="box-horizon">
      <div class="box-vertical">
        <label class="required">Preset Name</label>
        <input type="text" v-model="preset.Name" value="preset.Name" required>

        <label class="required">Waking Time</label>
        <input type="time" v-model="preset.WakingTime" value="preset.WakingTime" required>

        <label class="required">Song</label>

        <select type="select" v-model="preset.Song">
          <option value="Pharell Williams - Happy.mp3">Pharell Williams - Happy</option>
          <option value="C2C- Appy.mp3">C2C - Happy</option>
        </select>
      </div>

      <label class="required">Activation Flag</label>

      <div class="box-vertical">
        <div class="box-horizon">
          <input type="checkbox" v-model="days[0]" value="1">Lundi
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[1]" value="1">Mardi
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[2]" value="1">Mercredi
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[3]" value="1">Jeudi
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[4]" value="1">Vendredi
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[5]" value="1">Samedi
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[6]" value="1">Dimanche
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[7]" value="1">ACTIVE
        </div>
      </div>

      <div class="box-vertical">
        <label class="required">Challenge</label>

        <select type="select" v-model="preset.Challenge">
          <option value="Snake">Snake</option>
          <option value="Math">Math</option>
        </select>

        <br>
        <br>

        <label type="text">Alarm Preset Id : {{this.preset.AlarmPresetId}}</label>

        <br>
        <br>

        <label type="text">Clock Id : {{globalInfo.clocks[$route.params.id].clockId}}</label>
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
import { getGlobalUserInfo } from "@/api/UserApi";
import Vuex from "vuex";
import { formatActivationFlag, reformActivationFlag } from "@/api/formatActivationFlag.js";

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
      days: [],
      errors: [],
      info: {},
      globalInfo: {}
    };
  },
  async created() {
    
    this.globalInfo = await getGlobalUserInfo();
    console.log("globalInfo : " + this.globalInfo);
    this.$store.dispatch("setUserInfo", this.globalInfo);
    if(this.$route.params.presetId != null) {
      this.preset.AlarmPresetId   = this.globalInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId].presetId;
      this.preset.Name            = this.globalInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId].presetName;
      this.preset.WakingTime      = this.globalInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId].wakingTime;
      this.preset.Song            = this.globalInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId].song;
      this.preset.ActivationFlag  = this.globalInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId].activationFlag;
      this.preset.Challenge       = this.globalInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId].challenge;
      
      this.challenges = this.globalInfo.challenges;
    }
    this.days = formatActivationFlag(this.preset.ActivationFlag);
    if(this.preset.ActivationFlag & 1 != 0) {
      this.days[7] = true;
    } 
    else {
      this.days[7] = false;
    }
  },
  async mounted() {
    //this.id = this.$route.params.id;
    
    this.preset.clockId = this.globalInfo.clocks[this.$route.params.id].clockId 
    console.log(this.globalInfo.clocks[this.$route.params.id].presets[this.$route.params.presetId])
  },

  methods: {
    
    async onSubmit(event) {
      event.preventDefault();
      var errors = [];
      this.preset.ActivationFlag = reformActivationFlag(this.days);

      if (!this.preset.Name) errors.push("Name");
      if (!this.preset.WakingTime) errors.push("WakingTime");

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
      this.$router.push('/clock/' + this.$route.params.id + '/Presets')
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