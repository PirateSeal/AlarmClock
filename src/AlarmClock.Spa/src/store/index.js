import Vuex from 'vuex'
import Vue from 'vue'

import User from './user/'

Vue.use(Vuex)
export default new Vuex.Store({
  modules: {
    User,
    Tags
  },
  strict: process.env.NODE_ENV !== 'production'
})
