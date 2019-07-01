<template>
  <div class="container">
    <div class="presetlist">
      <PresetList v-for="(preset, index) in Presets" :key="preset.presetId" :preset="preset" :idx="index"></PresetList>
    </div>
    <div class="CreatePreset" @click="$router.push('/NewPreset/'+$route.params.id)" ></div>    

  </div>
</template>

<script>
import ClockPreset from "@/components/Home/home_connected/clock/clock_preset";
import { mapGetters } from "vuex";
import { getGlobalUserInfo } from "@/api/UserApi";

export default {
  components: {
    PresetList: ClockPreset
  },
  data() {
    return {
      Presets: []
    };
  },
  computed: {
    ...mapGetters({
      getUserInfo: "getUserInfo"
    })
  },
 
 async mounted() {
    this.Presets = await getGlobalUserInfo();
    console.log(this.globalInfo);
    this.$store.dispatch("setUserInfo", this.globalInfo);
  },

};
</script>
<style lang="scss" scoped>
.container{
  display: flex;
  flex-direction: column;
  align-content: center;
  .presetlist{
    display: flex;
    flex-direction: row;
    width: 100%;
    
  }
}
</style>

<style lang="scss" scoped>
.container {
  display: flex;
  flex-direction: column;
  align-content: center;
  .CreatePreset {
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
    display: flex;
    flex-direction: row;
    width: 100%;
    flex-wrap: wrap;
  }
}
</style>
