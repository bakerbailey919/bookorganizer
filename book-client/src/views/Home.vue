<template>
  <div class="home">
    <book-list />
  </div>
</template>

<script>
import BookList from "../components/BookList.vue";

export default {
  name: "home",
  components: {
    BookList,
  },
};
</script>

<style scoped>
</style>