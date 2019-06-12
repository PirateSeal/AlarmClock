import "./main.vendors";
import Vue from "vue";
import App from "./App.vue";
import router from "./main.router";

Vue.config.productionTip = false;

const main = async () => {
    new Vue({
        router,
        render: h => h(App)
    }).$mount("#app");
};

main();
