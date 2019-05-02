import { types } from './mutation'
// import { request } from '../../utils/request'
export const setUser = ({ commit }, data) => {
  commit(types.SET_USER, data)
}
