import axios from 'axios';

export default {
  getBooks() {
    return axios.get('/books');
  },
};
