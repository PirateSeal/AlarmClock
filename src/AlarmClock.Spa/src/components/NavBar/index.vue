<template>
  <div class="navbar">
    <div class="left">
      <div class="link" :class="{active: currentRoute === '/'}" @click="$router.push('/')">Home</div>
    </div>
    <div class="right">
      <div class="link" :class="{active: currentRoute === '/login'}" @click="$router.push('/login')">Login</div>
      <div v-if="auth" :class="{active: currentRoute === '/logout'}" class= "link" @click="$router.push('/logout')">Logout</div>
    </div>
  </div>
</template>

<script>
import AuthService from "../../services/AuthService";
export default {
  name: 'NavBar',
  data() {
    return {};
  },
  mounted() {
  
  },
  computed: {
    auth: () => AuthService ? AuthService.isConnected : false,
    currentRoute() {
      if(!this || !this.$route) return;
      return this.$route.path
    }
    
  },
  methods: {
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
  .left,
  .right {
    display: flex;
    .link {
      display: flex;
      align-items: center;
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
          content: '';
          width: 100%;
          height: 100%;
          border-bottom: 5px solid #00000067;

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