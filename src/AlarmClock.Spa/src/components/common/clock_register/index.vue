<template>
  <div class="clock_register_form">
    
     Enter Guid diplay on clock
    <input type="text" v-model="item.StrGuid" class="clockName">
    <div class="sub" @click="submit()">register</div>
  </div>
</template>

<script>
import {claimClockAsync,createClockAsync } from "@/api/clockApi";

import AuthService from '../../../services/AuthService';
import {getUserIdByEmail} from  "@/api/UserApi";


export default {
  name: "clock_register",
  data() {
    return {
      item: {
      }

    }
  },
  
  methods: {
    submit(){
 //     item.id = getUserIdByEmail(AuthService.email)
     var res =  claimClockAsync(this.item);
    console.log(res);
    }
  }
}
</script>

<style lang="scss" scoped>

.clock_register_form {
  display: block;
  margin-left: auto;
  margin-right: auto;

  .sub{
    &:hover{
      color: white;
      
    }
  }
}


</style>
