<template>
  <div id="app">
    <app-header />
    <app-footer />
  </div>
</template>

<script>
import AppHeader from "./components/AppHeader.vue";
import AppFooter from "./components/AppFooter.vue";

export default {
  name: "App",
  components: {
    AppHeader,
    AppFooter,
  },
};
</script>

<style>
#app {
  background-color: #f3f3f3;
  font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
  color: #1c1c1c;
}
</style>
