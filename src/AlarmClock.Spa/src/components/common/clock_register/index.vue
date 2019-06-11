<template>
  <div class="clock_register_form">
    <img src="../../../../public/assets/Clock/newClock.png">
    <input type="text" v-model="item.Name" class="clockName">
    <div class="sub" @click="submit()">register</div>
  </div>
</template>

<script>
import {createClockAsync } from "@/api/clockApi";
import AuthService from '../../../services/AuthService';
import {getUserIdByEmail} from  "@/api/UserApi";


export default {
  name: "clock_register",
  data() {
    return {
      item: {}

    }
  },
  
  methods: {
    submit(){
 //     item.id = getUserIdByEmail(AuthService.email)
      createClockAsync(this.item);
    }
  }
}
</script>

<style lang="scss" scoped>

.clock_register_form {
  display: block;
  margin-left: auto;
  margin-right: auto;
}

</style>
