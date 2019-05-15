<template>
  <div class="container">
    <div v-for="preset in Presets" :key="preset.presetId" :preset="preset"></div>
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
      Props: {
        preset: {
          type: Object,
          required: true
        }
      }
    };
  },
  computed: {
    ...mapGetters({
      getUserInfo: "getUserInfo"
    })
  },
  mounted() {
    this.Presets = this.getUserInfo.clocks[this.$route.params.id].presets;
  }
};
</script>
