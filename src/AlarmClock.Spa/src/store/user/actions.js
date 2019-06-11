import { types } from "./mutation";
import { getGlobalUserInfo } from "@/api/UserApi";

// import { request } from '../../utils/request'
export const setUserInfo = ({ commit }, data) => {
    commit(types.SET_USERINFO, data);
};

 
