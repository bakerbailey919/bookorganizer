<template>
  <div>
    <div>Book Dashboard</div>
    <button type="button" class="btn" @click="reloadPage()">Refresh</button>
    <book-card />
  </div>
</template>

<script>
import BookService from "../services/BookService.js";
import BookCard from "../components/BookCard.vue";

export default {
  name: "book-list",
  components: {
    BookCard,
  },
  methods: {
    reloadPage() {
      window.location.reload();
    },
  },
  created() {
    BookService.getBooks()
      .then((response) => {
        this.devices = response.data;
      })
      .catch((error) => {
        console.error(error);
      });
  },
};
</script>