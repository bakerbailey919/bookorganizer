import Vue from 'vue';
import App from './App.vue';
import router from './router/index';
import store from './store/index';
import axios from 'axios';
import { MdButton, MdContent, MdTabs } from 'vue-material/dist/components';
import 'vue-material/dist/vue-material.min.css';
import 'vue-material/dist/theme/default.css';

Vue.use(MdButton);
Vue.use(MdContent);
Vue.use(MdTabs);

Vue.config.productionTip = false;

axios.defaults.baseURL = 'http://localhost:5000/api/v1';

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount('#app');
