<template>
  <header>
    <nav class="navbar navbar-light fixed-top">
      <router-link v-bind:to="{ name: 'home' }" class="navbar-brand" href="#">
      </router-link>
      <div class="nav-buttons">
        <router-link v-bind:to="{ name: 'home' }" exact>Home</router-link>
        <router-link v-bind:to="{ name: 'register' }" v-if="!$store.state.token"
          >&nbsp;|&nbsp;Register</router-link
        >
        <router-link v-bind:to="{ name: 'login' }" v-if="!$store.state.token"
          >&nbsp;|&nbsp;Login</router-link
        >
        <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token"
          >&nbsp;|&nbsp;Logout</router-link
        >
        <router-link v-bind:to="{ name: 'mybooks' }" v-if="!$store.state.token"
          >&nbsp;|&nbsp;My Books</router-link
        >
        <router-link v-bind:to="{ name: 'browse' }" v-if="!$store.state.token"
          >&nbsp;|&nbsp;Browse</router-link
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
