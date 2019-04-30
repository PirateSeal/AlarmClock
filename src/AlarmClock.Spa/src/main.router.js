// Vue router setup
import Vue from "vue";
import VueRouter from "vue-router";
Vue.use(VueRouter);

import requireAuth from "./helpers/requireAuth";

// Components
import Home from "./views/Home.vue";
import Login from "./views/Login.vue";
import Logout from "./views/Logout.vue";
import Profile from "./views/Profile.vue";
import ClockRegister from "./views/ClockRegister.vue";

const routes = [
    { path: "", component: Home },
    { path: "/login", component: Login },
    { path: "/logout", component: Logout, beforeEnter: requireAuth },
    { path: "/Home", component: Home, beforeEnter: requireAuth },
    { path: "/Clock/register", component: ClockRegister, beforeEnter: requireAuth },
    
];

export default new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes
});
