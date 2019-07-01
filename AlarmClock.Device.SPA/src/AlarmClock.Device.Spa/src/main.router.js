/*
 * File: main.router.js                                                        *
 * Project: alarmclock                                                         *
 * File Created: Tuesday,2nd June 2019 02:22:06 pm                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 6th June 2019 9:59:57 am                           *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

// Vue router setup
import Vue from "vue";
import VueRouter from "vue-router";
Vue.use(VueRouter);

import Home from "./components/Home";
import MainMenu from "./components/MainMenu";

import Snake from "./components/Snake";
import MathGame from "./components/Math";
import EndGame from "./components/EndGame";

const routes = [
    { path: "", component: Home },
    { path: "/MainMenu", component: MainMenu },
    { path: "/Snake/:Time/:id", component: Snake },
    { path: "/Math/:Time/:id", component: MathGame },
    { path: "/EndGame/:Score/:Limite/:Time/:id", component: EndGame }
];

export default new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes
});
