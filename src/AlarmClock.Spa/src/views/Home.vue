<template>
  <div class="container">
    <HomeIn v-if="auth.isConnected"/>
    <HomeOut v-else/>
  </div>
</template>

<script>
import AuthService from "../services/AuthService";
import HomeOut from "../components/Home/HomeOut.vue";
import HomeIn from "../components/Home/HomeIn.vue";
import { METHODS } from 'http';
export default {
  components: {
    HomeOut: HomeOut,
    HomeIn: HomeIn

  },
  computed: {
    auth: () => AuthService 
  }
  
};
</script>

<style lang="scss">
.container{
  width: 100%;
  display: flex;
  align-items: center;
  text-align: center;
  
}
</style>