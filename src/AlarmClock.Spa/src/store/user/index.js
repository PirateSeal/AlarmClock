import mutations from "./mutation";
import * as getters from "./getters";
import * as actions from "./actions";
import { getGlobalUserInfo } from "@/api/UserApi";

//gerer User obj with multi params

const state = {
    userInfo : getGlobalUserInfo
};

export default {
    state,
    getters,
    mutations,
    actions
};
