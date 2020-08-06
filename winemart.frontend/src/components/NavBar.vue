<template>
    <div class="nav-container">
      <router-link to="/">
        <img id="logo" alt="brand logo" src="../assets/images/logo.png"/>
      </router-link>
      <h1>Admin Center</h1>
      <app-button
        id="navInventory"
        @button:click="changeRoute('/inventory')"
        is-full-width
      >
        Inventory
      </app-button>
      <app-button
        id="navOrders"
        @button:click="changeRoute('/orders')"
        is-full-width
      >
        View Orders
      </app-button>
      <app-button
        id="navCustomers"
        @button:click="changeRoute('/customers')"
        is-full-width
      >
        Customers
      </app-button>
      <app-button
        id="navInvoice"
        @button:click="changeRoute('/invoice/new')"
        is-full-width
      >
        Create Invoice
      </app-button>
    </div>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator';
import AppButton from "@/components/AppButton.vue";

@Component({
    name: 'NavBar',
    components: { AppButton }
})

export default class NavBar extends Vue{
  async changeRoute(route: string){
    await this.$router.push(route);
  }
};
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

img#logo {
    max-height: 250px;
    width: 100%;
}

h1 {
  font-size: 1.2rem;
  margin: 1rem 0;
  font-weight: 600;
}


</style>