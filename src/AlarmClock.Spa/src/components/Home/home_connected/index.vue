<template>
  <div class="Homeloged">
    <div class="displayed">Vos clock</div>
    <clock v-for="(clock, index) in globalInfo.clocks" :key="`${clock.title}${index}`" :clock="clock"/>
  </div>
</template>

<script>
import clock from "./clock";
import { deleteClockAsync } from "@/api/clockApi";
import { getGlobalUserInfo } from '@/api/UserApi'
import { mapGetters } from 'vuex'
import Vuex from 'vuex';



export default {
  name: "home_connected_index",
  components: {
    clock
  },
  async mounted() {
    this.globalInfo = await getGlobalUserInfo()
    console.log(this.globalInfo)
    await this.$store.dispatch('setUserInfo', this.globalInfo)
  },
    computed: {
    ...mapGetters({
      getUserInfo: 'getUserInfo'
    })
  },
  data() {
    return {
      globalInfo: {}
    };
  }
  
};
</script>
<style lang="scss" scoped>
.displayed 
{
  display: block;
  margin-left: auto;
  margin-right: auto;
}

.Homeloged {
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