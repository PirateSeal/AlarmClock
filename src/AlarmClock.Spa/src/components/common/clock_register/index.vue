<template>
  <div class="clock_register_form">
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
