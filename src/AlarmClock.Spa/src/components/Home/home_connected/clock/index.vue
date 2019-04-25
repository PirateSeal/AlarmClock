<template>
  <div class="Clock">

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

  async mounted() {
  },
  data() {
    return {
       clocks_preset: [
        {
          title: 'yolo',
          time: '18:56',
          days: [
            1,
            5,
            3,
            7
          ]
        },
        {
          title: 'preset2',
          time: '19:33',
          days: [
            1,
            2,
            4,
            7
          ]
        },
        {
          title: 'preset3',
          time: '07:56',
          days: [
            1,
            5,
            
          ]
        },
        {
          title: 'preset4',
          time: '07:56',
          days: [
            1,
            5,
          ]
        },
        {
          title: 'preset5',
          time: '07:56',
          days: [
            1,
            5,
            
          ]
        }
      ],
    };
  },
  methods: {
    days() {
      return days;
    },
    isDayActive(clock, index) {
      return clock.days.find(e => e === index + 1);
    },
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
  overflow: hidden;
  transition: all 0.5s;
  border-radius: 25px 25px 25px 25px;
  box-shadow: 0px -1px 30px 0px rgba(0, 0, 0, 0.9);
}
</style>
