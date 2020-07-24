<template>
    <div class="nav-container"></div>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator';

@Component({
    name: 'NavBar',
    components: {}
})

export default class NavBar extends Vue{};
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";

.nav-container {
  //background-color: #7952b3;
  background: $primary;
  height: 100vh;
  width: $nav-width;
  padding: 0.8rem;
  box-shadow: 0 1px 1px rgba(0, 0, 0, 0.12), 0 1px 1px rgba(0, 0, 0, 0.24);
  box-sizing: border-box;
  display: flex;
  flex-direction: column;
  
}

#businessLogo {
  width: 100%;
}

h1 {
  font-size: 1.2rem;
  margin: 1rem 0;
}


</style>