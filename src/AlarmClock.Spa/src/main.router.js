// Vue router setup
import Vue from "vue";
import VueRouter from "vue-router";
Vue.use(VueRouter);

import requireAuth from "./helpers/requireAuth";

// Components
import Home from "./components/Home/Home.vue";
import HomeLoged from "./components/Home/HomeLoged.vue";
import Login from "./views/Login.vue";
import Logout from "./views/Logout.vue";
import Profile from "./views/Profile.vue";

const routes = [
    { path: "", component: Home },
    { path: "/loged", component: HomeLoged },
    { path: "/login", component: Login },
    { path: "/logout", component: Logout, beforeEnter: requireAuth },
    { path: "/Profile", component: Profile, beforeEnter: requireAuth }
];

export default new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes
});
