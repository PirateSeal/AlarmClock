<template>
  <div class="navbar">
    <div class="left">
      <div class="link" :class="{active: currentRoute === '/'}" @click="$router.push('/')">Home</div>
    </div>
    <div class="right">
      <div
        class="link"
        :class="{active: currentRoute === 'Account/login'}"
        @click="login('Base')"
      >Login</div>
      <div
        v-if="auth"
        :class="{active: currentRoute === '/logout'}"
        class="link"
        @click="$router.push('/logout')"
      >Logout</div>
    </div>
  </div>
</template>

<script>
import AuthService from "../../services/AuthService";
import Vue from 'vue'
export default {
  name: "NavBar",
  data() {
    return {
    endpoint: null

    };
  },
  mounted() {
      AuthService.registerAuthenticatedCallback(() => this.onAuthenticated());
  },
  computed: {
    auth: () => (AuthService ? AuthService.isConnected : false),
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
       this.$router.replace("/");
    }
  }
};
</script>





<style lang="scss" scoped>
.navbar {
  height: 6vh;
  width: 100%;
  display: flex;
  justify-content: space-between;
  background: #e7a61a;
  overflow: hidden;
  box-shadow: 0px 0.6px 0px 0.5px rgba(158, 158, 158, 1);
  z-index: 1;
  
background: rgb(2,0,36);
background: linear-gradient(90deg, rgba(2,0,36,1) 0%, rgba(0,88,106,1) 36%, rgba(0,88,106,1) 69%, rgba(2,0,36,1) 100%);

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
          border-bottom: 5px solid #00000067;
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