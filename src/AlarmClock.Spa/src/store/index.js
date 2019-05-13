import Vuex from 'vuex'
import Vue from 'vue'

import User from './user/'

Vue.use(Vuex)
export default new Vuex.Store({
  modules: {
    User
  },
  strict: process.env.NODE_ENV !== 'production'
})
// 10.10.90.229