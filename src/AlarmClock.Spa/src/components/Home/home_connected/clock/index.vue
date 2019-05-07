<template>
  <div class="Clock" @click="$router.push('/Clock/'+clock.id)" >
      {{clock.title}}
  </div>
</template>

<script>
import days from "@/components/enums/days";
import clock_preset from './clock_preset'
export default {
  name: "clock",
  props: {
    clock: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
       clocks_preset: [],
    };
  },
  methods: {

  }
};
</script>
<style lang="scss" scoped>
.clock{
  min-height: 256px;
  height: 256px;
  min-width: 128px;
  width: 512px;
  max-width: 512px;
  flex-grow: 1;
  margin: 2.5%;
  background: rgb(1, 1, 133);
  display: flex;
  align-items: center;
  justify-content: flex-start;
  flex-direction: column;
  background-color: red;
  overflow: hidden;
  transition: all 0.5s;
  border-radius: 25px 25px 25px 25px;
  box-shadow: 0px -1px 30px 0px rgba(0, 0, 0, 0.9);
}
</style>
