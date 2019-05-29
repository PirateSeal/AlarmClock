<template>
  <div class="displayed">
    <img src="../../../../public/assets/Clock/SVG/Asset 1.svg">
    <img src="../../../../public/assets/Clock/homeDisconnect.png" class="img">
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

.displayed 
{
  display: block;
  margin-left: auto;
  margin-right: auto;
}

.img
{
  width:400px;
  height:400px; 
}

</style>