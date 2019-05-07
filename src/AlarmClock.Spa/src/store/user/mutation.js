export const types = {
  SET_USERINFO: 'SET_USERINFO'
}

const mutations = {
  [types.SET_USERINFO] (state, data) {
    this.state.userInfo = data
  }
}

export default mutations
