<template>
  <div class="container">
  </div>
</template>

<script>
import AuthService from "../services/AuthService";
import ClockPreset from "@/components/Home/home_connected/clock/clock_preset/";


export default {
  components: {

  },
  data() {
    return {
    }
  }
};
</script>

<style lang="scss">
.container{
  width: 100%;
  height: calc(100vh - 48px);
  display: flex;
  align-items: center;
  text-align: center;  
}
</style>