<template>
  <div class="home_disconnected">
    Welcome To
    <div class="title">
      <div class="Logo">AlarmClock</div>
    </div>
  </div>
</template>

<script>

export default {
  name: "home_disconnected_index",
  data() {
    return {
    endpoint: null

    };
  }
};
</script>
<style lang="scss" scoped>
.Logo{
    background: url("~/assets/logo.png");
  //  background-repeat: no-repeat;
    background-size: 100%;
    height: 500px;
    width: 500px;
   border-radius: 10px;
}
</style>
