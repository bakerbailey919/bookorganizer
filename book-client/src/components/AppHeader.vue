<template>
  <header>
    <nav>
      <div class="nav-buttons">
        <md-display-4>BookLand</md-display-4>
        <md-button v-bind:to="{ name: 'home' }" exact class="md-accent"
          >Home</md-button
        >
        <md-button
          v-bind:to="{ name: 'register' }"
          exact
          class="md-accent"
          v-if="!$store.state.token"
          >Register</md-button
        >
        <md-button
          v-bind:to="{ name: 'login' }"
          exact
          class="md-accent"
          v-if="!$store.state.token"
          >Login</md-button
        >
        <md-button
          v-bind:to="{ name: 'logout' }"
          exact
          class="md-accent"
          v-if="$store.state.token"
          >Logout</md-button
        >
        <md-button
          v-bind:to="{ name: 'mybooks' }"
          exact
          class="md-accent"
          v-if="$store.state.token"
          >My Books</md-button
        >
        <md-button v-bind:to="{ name: 'browse' }" exact class="md-accent"
          >Browse</md-button
        >
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
nav {
  background-color: #f3f3f3;
  box-shadow: 0 1px 5px 0 rgba(0, 0, 0, 0.3);
}
</style>
