<template>
  <div class="container">
    <homeConnected v-if="AuthService.isConnected"/>
    <homeDisconnected v-else/>
  </div>
</template>

<script>
import AuthService from "../services/AuthService";
import home_connected from "@/components/Home/home_connected";
import home_disconnected from "@/components/Home/home_disconnected";

export default {
  components: {
    homeConnected: home_connected,
    homeDisconnected:  home_disconnected

  },
  data() {
    return {
      AuthService
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