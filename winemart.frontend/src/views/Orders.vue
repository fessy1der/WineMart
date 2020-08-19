<template>
  <div>
    <h1 id="ordersTitle">
      All Orders
    </h1>
    <hr />
    <table id="sales-orders" class="tbl" v-if="orders.length">
      <thead>
        <tr>
          <th>CustomerId</th>
          <th>OrderId</th>
          <th>Order Total</th>
          <th>Order Status</th>
          <th>Mark Complete</th>
        </tr>
        <tr v-for="order in orders" :key="order.id">
          <td>
            {{ order.customer.id }}
          </td>
          <td>
            {{ order.id }}
          </td>
          <td>
            {{ getTotal(order) | price }}
          </td>
          <td :class="{ green: order.isPaid }">
            {{ getStatus(order.isPaid) }}
          </td>
          <td>
            <div
              v-if="!order.isPaid"
              class="lni-check-mark-circle order-complete green"
              @click="markComplete(order.id)"
            ></div>
          </td>
        </tr>
      </thead>
    </table>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { OrderService } from "@/services/order-service";
import { IOrder } from "@/types/Order";

const orderService = new OrderService();

@Component({ name: "Orders" })
export default class Orders extends Vue {
  orders: IOrder[] = [];
  getTotal(order: IOrder) {
    return order.salesOrderItems.reduce(
      (a, b) => a + b["product"]["price"] * b["quantity"],
      0
    );
  }
  getStatus(isPaid: boolean) {
    return isPaid ? "Paid in Full" : "Unpaid";
  }
  async markComplete(orderId: number) {
    await orderService.markOrderComplete(orderId);
    await this.initialize();
  }
  async initialize() {
    this.orders = await orderService.getOrders();
  }
  async created() {
    await this.initialize();
  }
}
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";
.green {
font-weight: bold;
color: $green;
}
.order-complete {
cursor: pointer;
text-align: center;
}
</style>