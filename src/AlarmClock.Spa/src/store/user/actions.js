import { types } from './mutation'
// import { request } from '../../utils/request'
export const setUserInfo = ({ commit }, data) => {
  commit(types.SET_USERINFO, data)
}
