<template>
  <header>
    <nav class="navbar navbar-light fixed-top">
      <router-link v-bind:to="{ name: 'home' }" class="navbar-brand" href="#">
      </router-link>
      <div class="nav-buttons">
        <router-link v-bind:to="{ name: 'home' }" exact>Home</router-link>
      </div>
    </nav>
  </header>
</template>

<script>
export default {
  name: 'AppHeader',
  data() {
    return {};
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
header {
  height: 86px;
  color: #81888b;
  grid-area: navBar;
  text-align: center;
}
</style>
