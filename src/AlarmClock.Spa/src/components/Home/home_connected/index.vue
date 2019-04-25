<template>
  <div class="Homeloged">
    <div v-on:click="Form()">
    <!-- <router-link to='/PresetForm'> -->
      <clock v-for="(clock, index) in clocks" :key="`${clock.title}${index}`" :clock="clock"/>
    <!-- </router-link> -->
    </div>
  </div>
</template>

<script>
import days from '@/components/enums/days'
import clock from './clock_preset'
export default {
  name: "home_connected_index",
  components: {
    clock
  },
  data() {
    return {
      days,
      clocks: [
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
    }
  },
  
  methods: {
    Form() {
      this.$router.push("/PresetForm");
    }
  }
};

</script>
<style lang="scss" scoped>

.Homeloged{
  width: 100%;
  height: 100%;
  // background: red;
  display: flex;
  align-items: center;
  justify-content: space-around;
  flex-wrap: wrap;
  overflow-y: scroll;
  overflow: hidden;
}
</style>