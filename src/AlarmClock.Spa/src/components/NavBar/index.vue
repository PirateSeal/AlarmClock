<template>
  <div class="navbar">
    <div class="left">
      <div class="link" :class="{active: currentRoute === '/'}" @click="$router.push('/')">Home</div>
    </div>
    <div class="right">
      <div
        v-if="AuthService.isConnected"
        :class="{active: currentRoute === '/logout'}"
        class="link"
        @click="logout"
      >Logout | {{ AuthService.isConnected }}</div>
      <div
        v-else
        class="link"
        :class="{active: currentRoute === 'Account/login'}"
        @click="login('Base')"
      >Login | {{ AuthService.isConnected }}</div>
    </div>
  </div>
</template>

<script>
import AuthService from "../../services/AuthService";
import Vue from "vue";
export default {
  name: "NavBar",
  data() {
    return {
      AuthService,
      endpoint: null
    };
  },

  mounted() {
    // AuthService.registerAuthenticatedCallback(() => this.onAuthenticated());
  },

  beforeDestroy() {
    // AuthService.removeAuthenticatedCallback(() => this.onAuthenticated());
  },

  computed: {
    currentRoute() {
      if (!this || !this.$route) return;
      return this.$route.path;
    }
  },

  methods: {
    login(provider) {
      AuthService.login(provider);
    },
    onAuthenticated() {
      console.log(this.AuthService.isConnected);
      this.$router.replace("/home");
    },
    logout() {
      this.$router.replace("/logout");
    }
  }
};
</script>





<style lang="scss" scoped>
.navbar {
  height: 48px;
  width: 100%;
  display: flex;
  justify-content: space-between;
  background: #e7a61a;
  overflow: hidden;
  box-shadow: 0px 0.6px 0px 0.5px rgba(158, 158, 158, 1);
  z-index: 995384;

  background: rgb(2, 0, 36);
  background: linear-gradient(
    90deg,
    rgba(2, 0, 36, 1) 0%,
    rgba(0, 88, 106, 1) 36%,
    rgba(0, 88, 106, 1) 69%,
    rgba(2, 0, 36, 1) 100%
  );

  .left,
  .right {
    display: flex;
    .link {
      display: flex;
      align-items: center;
      text-align: center;
      padding: 0 40px;
      transition: all 0.5s;
      color: white;
      position: relative;
      &:hover {
        opacity: 0.6;
        transform: scale(1.4);
        cursor: pointer;
        .active {
        }
      }
      &.active {
        &:after {
          position: absolute;
          content: "";
          width: 100%;
          height: 100%;
          border-bottom: 5px solid #ffffff67;
          left: 0%;
        }
      }
    }
  }
  .left {
    .link {
    }
  }
  .right {
    .link {
    }
  }
}
</style>