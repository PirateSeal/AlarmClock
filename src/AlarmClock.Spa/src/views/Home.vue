<template>
    <!-- <section class="jumbotron text-center">
        <div class="container">
            <h1 class="jumbotron-heading">Bienvenue sur ITI.PrimarySchool</h1>
            <p class="lead text-muted">Cette application est réalisée à l'aide du framework Vue 2.</p>
            <p>
                <a href="http://vuejs.org/v2/guide/" class="btn btn-primary my-2">Guide Vue 2</a>
                <a href="http://vuejs.org/v2/api/" class="btn btn-secondary my-2">Documentation API Vue 2</a>
            </p>
        </div> -->
        <HomeIn
            v-if="auth"
        />
        <HomeOut
            v-else
        />
    <!-- </section>
    if composant A ? composant A : composant B car c'est une view !!! -->
</template>

<script>
import AuthService from "../services/AuthService";
import HomeOut from "../components/Home/HomeOut.vue";
import HomeIn from "../components/Home/HomeIn.vue";
export default {
    components: {
        HomeOut: HomeOut,
        HomeIn: HomeIn
    },
    computed: {
        auth: () => (AuthService ? AuthService.isConnected : false)
    }
}
</script>

<style lang="scss">

</style>