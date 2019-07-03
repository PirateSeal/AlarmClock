<template>
  <div class="Homeloged">
    <div v-if="getUserInfo.clocks != ''">
      <div class="title">Vos clock</div>
      <div class="clocks-container">
        <clock
          v-for="(clock, index) in getUserInfo.clocks"
          :key="`${clock.title}${index}`"
          :clock="clock"
          :index="index"
        />
      </div>
    </div>
    <div class="info" v-else>
Please register a new clock </div>
  </div>
</template>

<script>
import clock from "./clock";
import { deleteClockAsync } from "@/api/clockApi";
import { getGlobalUserInfo } from "@/api/UserApi";
import { mapGetters } from "vuex";
import Vuex from "vuex";

export default {
  name: "home_connected_index",
  components: {
    clock
  },

    async mounted() {
    const globalInfo = await getGlobalUserInfo();
    console.log(globalInfo);
    this.$store.dispatch("setUserInfo", globalInfo);   
  },
  computed: {
    ...mapGetters({
      getUserInfo: "getUserInfo"
    })
  },
  data() {
    return {
    };
  }
};
</script>
<style lang="scss" scoped>
.displayed {
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
  flex-direction: column;

  .title {
    font-size: 30px;
  }
  .info{
    font-size: 50px;

  }
  overflow-y: scroll;
   overflow: hidden;
  .clocks-container {
    width: 100%;
    display: flex;
    flex-wrap: wrap;
    justify-content: space-around;
    flex-direction: row;
  }
}
</style>