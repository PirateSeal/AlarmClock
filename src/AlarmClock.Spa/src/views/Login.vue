<template>

</template>

<script>
import AuthService from '../services/AuthService'
import Vue from 'vue'

export default {
    data() {
        return {
            endpoint: null
        }
    },

    mounted() {
        AuthService.registerAuthenticatedCallback(() => this.onAuthenticated());
    },

    beforeDestroy() {
        AuthService.removeAuthenticatedCallback(() => this.onAuthenticated());
    },

    methods: {
        login(provider) {
            AuthService.login(provider);
        },

        onAuthenticated() {
            this.$router.replace('/');
        }
    }
}
</script>

<style lang="scss">
iframe {
  width: 100%;
  height: 600px;
}
</style>