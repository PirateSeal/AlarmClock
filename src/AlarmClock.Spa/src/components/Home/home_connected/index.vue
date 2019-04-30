<template>
  <div class="Homeloged">
    <clock v-for="(clock, index) in clocks_preset" :key="`${clock.title}${index}`" :clock="clock"/>
  <clockPreset></clockPreset>
  </div>
</template>

<script>
import clock from './clock'
import { GetAllClocksByUserId, deleteClockAsync } from "@/api/clockApi";
import ClockPreset from '@/components/Home/home_connected/clock/clock_preset'


export default {
  name: "home_connected_index",
  components: {
    clock,
    clockPreset
  },
  mounted() {
    clockList = GetAllClocksByUserId();
  },
  data() {
    return {
      clockList: [],
    };
  }
};

</script>
<style lang="scss" scoped>

.Homeloged{
  width: 100%;
  height: 100%;
  display: flex;
  align-items: center;
  justify-content: space-around;
  flex-wrap: wrap;
  //overflow-y: scroll;
 // overflow: hidden;
}
</style>