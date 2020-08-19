  
<template>
  <div>
    <h1 id="customersTitle">
      Manage Customers
    </h1>
    <hr />
    <div class="actions">
      <app-button @button:click="showCustomerModal">
        Add Customer
      </app-button>
    </div>
    <table id="customers" class="tbl">
      <tr>
        <th>Customer</th>
        <th>Address</th>
        <th>State</th>
        <th>Since</th>
        <th>Delete</th>
      </tr>
      <tr v-for="customer in customers" :key="customer.id">
        <td>
          {{ customer.firstName + " " + customer.lastName }}
        </td>
        <td>
          {{
            customer.primaryAddress.addressLine1 +
              " " +
              customer.primaryAddress.addressLine2
          }}
        </td>
        <td>
          {{ customer.primaryAddress.state }}
        </td>
        <td>
          {{ customer.createdOn | humanizeDate }}
        </td>
        <td>
          <div
            class="lni-cross-circle customer-delete"
            @click="deleteCustomer(customer.id)"
          ></div>
        </td>
      </tr>
    </table>

    <customer-modal
      @close="closeModal"
      @save:customer="saveNewCustomer"
      v-if="isAddCustomer"
    />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { ICustomer } from "@/types/Customer";
import AppButton from "@/components/AppButton.vue";
import CustomerService from "@/services/customer-service";
import CustomerModal from "@/components/CustomerModal.vue";

const customerService = new CustomerService();

@Component({
  name: "Customers",
  components: { AppButton, CustomerModal }
})

export default class Customers extends Vue {
  customers: ICustomer[] = [];
  isAddCustomer: boolean = false;

  showCustomerModal() {
    this.isAddCustomer = true;
  }

  closeModal() {
    this.isAddCustomer = false;
  }

  async saveNewCustomer(newCustomer: ICustomer) {
    await customerService.addCustomer(newCustomer);
    this.isAddCustomer = false;
    await this.initialize();
  }

  async deleteCustomer(id: number) {
    await customerService.deleteCustomer(id);
    await this.initialize();
  }

  async initialize() {
    this.customers = await customerService.getCustomers();
  }
  async created() {
    await this.initialize();
  }
}
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";
.customer-actions {
  display: flex;
  margin-bottom: 0.8rem;
  div {
    margin-right: 0.8rem;
  }
}
.customer-delete {
  cursor: pointer;
  font-weight: bold;
  font-size: 1.2rem;
  color: $red;
}
</style>