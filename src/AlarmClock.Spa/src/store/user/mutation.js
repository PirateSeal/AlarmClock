export const types = {
  SET_USER: 'SET_USER'
}

const mutations = {
  [types.SET_USER] (state, data) {
    this.state.user = data
  }
}

export default mutations
