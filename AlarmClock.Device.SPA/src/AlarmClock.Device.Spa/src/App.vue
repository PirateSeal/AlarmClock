<template>
  <div id="app">
    <header>
      <nav class="navbar navbar-expand-lg navbar-dark bg-dark"></nav>
    </header>

    <main role="main" class="p-3 p-md-4 p-lg-5">
      <router-view class="child"></router-view>
    </main>
  </div>
</template>

<script>
export default {
  data() {
    return {};
  },

  computed: {}
};
</script>

<style lang="scss" scoped>
.progress {
  margin: 0px;
  padding: 0px;
  height: 5px;
}

a.router-link-active {
  font-weight: bold;
}
</style>

<style lang="scss">
@import "./styles/global.scss";
</style>