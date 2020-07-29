<template>
  <div id="app">
    <div class="nav">
      <nav-bar />
    </div>
    <div class="main">
      <router-view />
    </div>
  </div>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator';
import NavBar from "@/components/NavBar.vue";

@Component({
  name: 'App',
  components: { NavBar }
})

export default class App extends Vue{};
</script>

<style lang="scss">
@import "@/scss/global.scss";

* {
  margin: 0;
}

a {
  text-decoration: none;
}


#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #fff;
  display: flex;

  .nav {
    position: fixed;
  }

  .main {
    padding: 1.2rem;
    width: 90%;
    margin: 1rem auto 1rem $nav-width;
    text-align: left;
  }
}

* {
  margin: 0;
}
a {
  text-decoration: none;
}
hr {
  border: 1px solid #ba54f5;
  margin: 1rem 0;
}


</style>
