<template>
  <div id="app">
    <Nav/>
    <router-view v-if="loaded" class="content"></router-view>
    <!-- <Footer /> -->
  </div>
</template>

<script>
import AuthService from "./services/AuthService";
import "./directives/requiredProviders";
import { state } from "./state";
import NavBar from "./components/NavBar";
import { getGlobalUserInfo } from "@/api/UserApi";


export default {
  name: "App",
  components: {
    Nav: NavBar
  },
  data() {
    return {
      state,
      loaded :  false 
    };
  },

  async mounted() {
    if(AuthService.isConnected){
    const globalInfo = await getGlobalUserInfo();
    console.log(globalInfo);
    this.$store.dispatch("setUserInfo", globalInfo);
    }
    this.loaded = true;

    
  },

  computed: {
    auth: () => AuthService,

    isLoading() {
      return this.state.isLoading;
    }
  }
};
</script>
<style lang="scss">
@import "./styles/global.scss";

</style>
<style lang="scss" scoped>
#app {
  width: 100%;
  height: 100vh;
  overflow: hidden;
  .content {
    display: flex;
    flex-wrap: center;
    align-items: center;
    overflow: hidden;
    overflow-y: scroll;
    text-align: center;
    height: 98vh;
    width: 100%;
    z-index: 0;
    background: #2E85BF;
	  background: linear-gradient(-45deg, #EE7752, #E73C7E, #23A6D5, #23D5AB); 
    background-size: 200%;


  }
}
</style>