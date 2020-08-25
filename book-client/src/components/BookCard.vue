<template>
  <div class="flex-card-header-container">
    <div class="card-body">
      <h5 class="card-title">{{book.title}}</h5>
      <p class="card-text">Id: {{book.bookId}}</p>
      <p class="card-text">Description: {{book.description}}</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "book-card",
  props: {
    book: Object,
  },
  methods: {},
};
</script>

<style scoped>
</style>