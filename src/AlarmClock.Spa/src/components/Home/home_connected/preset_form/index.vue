<template>
  <form @submit="onSubmit($event)">
    <div class="box-horizon">
      <div class="box-vertical">
        <label class="required">Preset Name</label>
        <input type="text" v-model="preset.PresetName" value="preset.PresetName" required>

        <label class="required">Waking Time</label>
        <input type="time" v-model="preset.WakingTime" value="preset.WakingTime" required>

        <label class="required">Song</label>

        <select type="select" v-model="preset.Song">
          <option value="Diggy_Diggy_Hole.mp4">Diggy Diggy Hole</option>
          <option value="Random_Music_1.mp4">Random Music 1</option>
          <option value="Random_Music_2.mp4">Random Music 2</option>
          <option value="Random_Music_3.mp4">Random Music 3</option>
          <option value="Random_Music_4.mp4">Random Music 4</option>
          <option value="Random_Music_5.mp4">Random Music 5</option>
          <option value="Random_Music_6.mp4">Random Music 6</option>
          <option value="Random_Music_7.mp4">Random Music 7</option>
          <option value="Random_Music_8.mp4">Random Music 8</option>
        </select>
      </div>

      <label class="required">Activation Flag</label>

      <div class="box-vertical">
        <div class="box-horizon">
          <input type="checkbox" v-model="preset.ActivationFlag[0]" value="1">Sunday
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="preset.ActivationFlag[1]" value="1">Monday
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="preset.ActivationFlag[2]" value="1">Tuesday
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="preset.ActivationFlag[3]" value="1">Wednesday
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="preset.ActivationFlag[4]" value="1">Thursday
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="preset.ActivationFlag[5]" value="1">Friday
        </div>
        <div class="box-horizon">
          <input type="checkbox" v-model="preset.ActivationFlag[6]" value="1">Saturday
        </div>
      </div>

      <div class="box-vertical">
        <label class="required">Challenge</label>

        <select type="select" v-model="preset.Challenge">
          <option value="BlindTest">BlindTest</option>
          <option value="Joke">Joke</option>
          <option value="Snake">Snake</option>
          <option value="Pacman">Pacman</option>
          <option value="Tetris">Tetris</option>
          <option value="ReflexTest">Reflex Test</option>
        </select>

        <br>
        <br>

        <label type="text">Alarm Preset Id : {{preset.AlarmPresetId}}</label>

        <br>
        <br>

        <label type="text">Clock Id : {{preset.ClockId}}</label>
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
} from "../../../../api/PresetApi.js";
export default {
  data() {
    return {
      id: 3,
      preset: {},
      mode: "edit",
      errors: []
    };
  },

  async mounted() {
    //this.id = this.$route.params.id;
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

      var errors = [];

      if (!this.preset.PresetName) errors.push("PresetName");
      if (!this.preset.WakingTime) errors.push("WakingTime");
      if (!this.preset.Song) errors.push("Song");
      if (!this.preset.ActivationFlag) errors.push("ActivationFlag");
      if (!this.preset.Challenge) errors.push("Challenge");
      if (!this.preset.AlarmPresetId) errors.push("AlarmPresetId");
      if (!this.preset.ClockId) errors.push("ClockId");

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