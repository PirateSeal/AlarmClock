<template>
  <div class="clock_register_form">
    
      <div class="title">Enter Guid displayed on clock</div>
    <input type="text" v-model="item.StrGuid" class="clockName">
    <button class="sub" @click="submit()">register</button>
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
  .title{
    font-size: 50px;
  }

  .sub{
    border: solid 1px ;
    &:hover{
      color: white;
      
    }
  }
}


</style>
