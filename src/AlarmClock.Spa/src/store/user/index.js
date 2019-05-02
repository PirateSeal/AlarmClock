import mutations from './mutation'
import * as getters from './getters'
import * as actions from './actions'

//gerer User obj with multi params

const state = {
  user: {
    info: {},
    clockInfo: {},
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
