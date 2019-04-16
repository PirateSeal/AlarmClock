<template>
  <div id="app">
    <Nav/>
    <div class="content">
      <router-view class="child"></router-view>
    </div>
    <!-- <Footer /> -->
  </div>
</template>

<script>
import AuthService from "./services/AuthService";
import "./directives/requiredProviders";
import { state } from "./state";
import NavBar from "./components/NavBar";

export default {
  name: "NavBar",
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
  width: 100vw;
  height: 100vh;
  .content {
    overflow: hidden;
    min-height: 80vh;
    z-index: 0;
  }
}
</style>