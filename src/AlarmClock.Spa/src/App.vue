<template>
  <div id="app">
    <Nav/>
    <router-view class="content"></router-view>
    <!-- <Footer /> -->
  </div>
</template>

<script>
import AuthService from "./services/AuthService";
import "./directives/requiredProviders";
import { state } from "./state";
import NavBar from "./components/NavBar";

export default {
  name: "App",
  components: {
    Nav: NavBar
  },
  data() {
    return {
      state
    };
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
    height: 94vh;
    width: 100%;
    z-index: 0;
    background: rgb(34,193,195);
    background: linear-gradient(337deg, rgba(34,193,195,1) 0%, rgba(253,187,45,1) 100%);
  }
}
</style>