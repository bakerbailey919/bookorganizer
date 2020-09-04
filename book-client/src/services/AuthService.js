import axios from 'axios';

export default {
  login(user) {
    return axios.post('/auth', user);
  },

  register(user) {
    return axios.post('/auth/register', user);
  },
};
