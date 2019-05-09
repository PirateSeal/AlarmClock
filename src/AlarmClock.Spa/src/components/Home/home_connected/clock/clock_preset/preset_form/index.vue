<template>
  <form @submit="onSubmit($event)">
    <div class="box-horizon">
      <div class="box-vertical">
        <label class="required">Preset Name</label>
        <input type="text" v-model="preset.name" value="preset.PresetName" required>

        <label class="required">Waking Time</label>
        <input type="time" v-model="preset.wakingTime" value="preset.WakingTime" required>

        <label class="required">Song</label>

        <input type="text" v-model="preset.song" value="preset.song" required>
      </div>

      <label class="required">Activation Flag</label>

      <div class="box-vertical">
        <div class="box-horizon">
          <input type="checkbox" v-model="days[0]" value="1">Sunday
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[1]" value="1">Monday
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[2]" value="1">Tuesday
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[3]" value="1">Wednesday
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[4]" value="1">Thursday
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[5]" value="1">Friday
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="days[6]" value="1">Saturday
        </div>
      </div>

      <div class="box-vertical">
        <label class="required">Challenge</label>

        <select type="select" v-model="preset.challenge">
          <option value="0">BlindTest</option>
          <option value="1">Joke</option>
          <option value="2">Snake</option>
          <option value="3">Pacman</option>
          <option value="4">Tetris</option>
          <option value="5">Reflex Test</option>
        </select>

        <br>
        <br>

        <label type="text">Alarm Preset Id : {{preset.alarmPresetId}}</label>

        <br>
        <br>

        <label type="text">Clock Id : {{preset.clockId}}</label>
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
  updatePresetAsync,
  getPresetAsync
} from "@/api/presetApi.js";
export default {
  computed: {
    ...mapGetters({
      getUserInfo: 'getUserInfo'
    })
  },
  data() {
    return {
      id: 3,
      preset: {},
      days: [true, false, true, true, false, true, false],
      mode: "edit",
      errors: [],
      globalInfo: {}
    };
  },

  async mounted() {
    //this.id = this.$route.params.id;
    
    this.globalInfo = await getGlobalUserInfo()
    console.log(this.$store);
    await this.$store.dispatch('setUserInfo', this.globalInfo)

    if (this.mode == "edit") {
      try {
        this.preset = await getPresetAsync(this.id);
      } catch (e) {
      }
    }
  },

  methods: {
    async onSubmit(event) {
      event.preventDefault();
      debugger;
      var errors = [];

      if (!this.preset.name) errors.push("Name");
      if (!this.preset.wakingTime) errors.push("WakingTime");
      if (!this.preset.song) errors.push("Song");
      // if (!this.preset.activationFlag) errors.push("ActivationFlag");
      if (!this.preset.challenge) errors.push("Challenge");
      if (!this.preset.alarmPresetId) errors.push("AlarmPresetId");
      if (!this.preset.clockId) errors.push("ClockId");

      this.errors = errors;

      if (errors.length == 0) {
        try {
          if (this.mode == "edit") await updatePresetAsync(this.preset);
          else await createPresetAsync(this.preset);
          this.$router.replace("");
        } catch (e) {
          console.error(e);
        }
      }
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