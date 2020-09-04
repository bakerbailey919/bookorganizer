<template>
  <div class="card" style="width: 25rem;">
    <div class="flex-card-header-container">
      <div class="card-body">
        <h5 class="card-title">Title: {{ book.title }}</h5>
        <p class="card-text">Id: {{ book.bookId }}</p>
        <p class="card-text">Description: {{ book.description }}</p>
      </div>
    </div>
  </div>
</template>

<script>
//import BookService from "../services/BookService.js";

export default {
  name: 'book-card',
  props: {
    book: Object,
  },
  methods: {},
};
</script>

<style scoped></style>
