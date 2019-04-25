<template>
  <div class="container">
<ClockRegisterForm></ClockRegisterForm>
  </div>
</template>

<script>

import ClockRegister from "@/components/common/clock_register";

export default {
  components: {
    ClockRegisterForm: ClockRegister

  },
  data() {
    return {
    }
  },
  computed: {
  }
  
};
</script>

<style lang="scss">
.container{
  width: 100%;
  height: calc(100vh - 48px);
  display: flex;
  align-items: center;
  text-align: center;  
}
</style>