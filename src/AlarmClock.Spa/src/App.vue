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
    display: flex;
    flex-wrap: center;
    align-items: center;
    text-align: center;
    overflow: hidden;
    min-width: 100%;
    min-height: 80vh;
    z-index: 0;
    background: rgb(34,193,195);
    background: linear-gradient(337deg, rgba(34,193,195,1) 0%, rgba(253,187,45,1) 100%);
  }
}
</style>