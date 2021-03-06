import Vue from 'vue'
import App from './App.vue'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue'
import Axios from 'axios'
import router from './router'

Vue.config.productionTip = false

Axios.defaults.baseURL = 'http://localhost:5000/api/'

Vue.use(BootstrapVue)

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
