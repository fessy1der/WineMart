import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import Inventory from "@/views/Inventory.vue";
import Customers from "@/views/Customers.vue";
import Orders from "@/views/Orders.vue";
import Invoice from "@/views/Invoice.vue";


Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'home',
    component: Inventory
  },
  {
    path: '/inventory',
    name: 'inventory',
    component: Inventory
  },
  {
    path: '/customers',
    name: 'customers',
    component: Customers
  },
  {
    path: '/orders',
    name: 'order',
    component: Orders
  },
  {
    path: '/invoice',
    name: 'invoice',
    component: Invoice
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});
export default router;
