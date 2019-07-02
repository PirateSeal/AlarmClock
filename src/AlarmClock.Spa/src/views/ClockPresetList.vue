<template>
  <div class="container">
    <div class="presetlist">
      <PresetList v-for="(preset, index) in Presets" :key="preset.presetId" :preset="preset" :idx="index"></PresetList>
    </div>
    <div class="CreatePreset" @click="$router.push('/NewPreset/'+ NewPresetId)" ></div>    

  </div>
</template>

<script>
import ClockPreset from "@/components/Home/home_connected/clock/clock_preset";
import { mapGetters } from "vuex";

export default {
  components: {
    PresetList: ClockPreset
  },
  data() {
    return {
      Presets: [],
      NewPresetId: '0'
    };
  },
  computed: {
    ...mapGetters({
      getUserInfo: "getUserInfo"
    })
  },
 async mounted() {
    this.Presets = this.getUserInfo.clocks[this.$route.params.id].presets;
    this.NewPresetId = this.getUserInfo.clocks[this.$route.params.id].clockId;
  }
};
</script>


<style lang="scss" scoped>
.container {
  display: flex;
  flex-direction: column;
  align-content: center;


  .CreatePreset {
    margin: 50px;
    background: url("~/assets/Plus.png");
    background-repeat: no-repeat;
    background-size: 100%;
    height: 128px;
    width: 128px;
    &:hover {
    opacity: 0.6;
    transform: scale(1.4);
    cursor: pointer;
  }
  }
  .presetlist {
justify-content: center;

    display: flex;
    flex-direction: row;
    width: 100%;
    flex-wrap: wrap;
  }
}
</style>
