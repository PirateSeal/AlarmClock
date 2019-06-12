<template>
  <div class="container">
      <Snake></Snake>
  </div>
</template>

<script>
import Snake from "@/games/Snake/Snake.vue";

export default {

  components: {    
      Snake: Snake
  },

  data() {

    return {
    }
  },

  computed: {
  }

};
</script>