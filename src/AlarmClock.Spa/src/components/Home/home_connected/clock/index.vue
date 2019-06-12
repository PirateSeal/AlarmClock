<template>
  <div class="Clock" @click="$router.push('/Clock/'+index+'/Presets')">
    <div class="clock-img"></div>
    <div class="text-info">
      <div class="name">{{clock.clockName}}</div>
      <div class="date">last seen date : {{clock.lastSeenDate}}</div>
      <div class="delete" @click="delet()" ></div>
    </div>
  </div>
</template>

<script>
import days from "@/components/enums/days";
import clock_preset from "./clock_preset";
import {deleteClockAsync} from  "@/api/clockApi.js"
export default {
  name: "clock",
  props: {
    clock: {
      type: Object,
      required: true
    },
    index: {
      type: Number,
      required: true
    }
  },
  mounted() {
    if (this.clock.clockName == "") this.clock.clockName = "defaultname";
  },
  data() {
    return {
      clocks_preset: []
    };
  },
  methods: {

    delet(){
      deleteClockAsync(this.clock.clockId);
      this.$router.push('/home')
      
    }
  }
};
</script>
<style lang="scss" scoped>
.Clock {
  background-repeat: no-repeat;
  min-height: 256px;
  height: 256px;
  min-width: 128px;
  width: 512px;
  max-width: 512px;
  flex-grow: 1;
  margin: 2.5%;
  display: flex;
  align-items: center;
  justify-content: flex-start;
  overflow: hidden;
  justify-content: space-around;
  transition: all 0.5s;
  border-radius: 25px 25px 25px 25px;
  box-shadow: 0px -1px 30px 0px rgba(0, 0, 0, 0.9);
  background-color: #37A0E6;
  transition: all 0.5s;
  position: relative;
  .text-info {
    display: flex;
    flex-direction: column;
    font-size: 25px;
  }
  .delete{
    width: 64px;
    height: 64px;
    background: url("~/assets/delete.png");
    background-size: 64px;
    background-repeat: no-repeat;
    

  }

  .clock-img {
    background: url("~/assets/Alarms_&_Clock_icon.png");
    background-repeat: no-repeat;
    background-size: 100%;
    height: 128px;
    width: 128px;
    flex-shrink: 0;
  }
      &:hover {
        opacity: 0.6;
        transform: scale(1.4);
        cursor: pointer;
      }

}
</style>
