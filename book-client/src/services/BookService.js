import axios from 'axios';

export default {
  getBooks() {
    return axios.get('/api/v1/book');
  },
};
