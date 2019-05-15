<template>
  <div class="Clock" @click="$router.push('/Clock/'+clock.clockId+'/Presets')">
    <div class="clock-img"></div>
    <div class="text-info">
      <div class="name">{{clock.clockName}}</div>
      <div class="date">last seen date : {{clock.lastSeenDate}}</div>
    </div>
  </div>
</template>

<script>
import days from "@/components/enums/days";
import clock_preset from "./clock_preset";
export default {
  name: "clock",
  props: {
    clock: {
      type: Object,
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
  methods: {}
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
  .text-info {
    display: flex;
    flex-direction: column;
    font-size: 25px;
  }
  .clock-img {
    background: url("~/assets/Alarms_&_Clock_icon.png");
    background-repeat: no-repeat;
    background-size: 100%;
    height: 128px;
    width: 128px;
    flex-shrink: 0;
  }
}
</style>
