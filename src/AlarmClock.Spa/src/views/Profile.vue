<template>
  <div></div>
</template>

<script>
import { GetUserInfo } from "../api/UserApi";
export default {
  data() {
    return { UserData: {} };
  },
  mounted() {
    this.UserData.RefreshData();
  },
  methods: {
    async RefreshData(UserId) {
      try {
        this.UserData = await GetUserInfo();
      } catch (e) {
        console.error(e);
      }
    }
  }
};
</script>
