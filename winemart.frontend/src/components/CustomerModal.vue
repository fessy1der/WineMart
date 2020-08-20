<template>
  <app-modal>
    <template v-slot:header>
      Add New Customer
    </template>
    <template v-slot:body>
      <ul class="newCustomer">
        <li>
          <label for="firstName">First Name</label>
          <input type="text" id="firstName" v-model="customer.firstName" />
        </li>
        <li>
          <label for="lastName">Last Name</label>
          <input type="text" id="lastName" v-model="customer.lastName" />
        </li>
        <li>
          <label for="address1">Address Line 1</label>
          <input
            type="text"
            id="address1"
            v-model="customer.address.addressLine1"
          />
        </li>
        <li>
          <label for="address2">Address Line 2</label>
          <input
            type="text"
            id="address2"
            v-model="customer.address.addressLine2"
          />
        </li>
        <li>
          <label for="city">City</label>
          <input type="text" id="city" v-model="customer.address.city" />
        </li>
        <li>
          <label for="state">State</label>
          <input
            type="text"
            id="state"
            v-model="customer.address.state"
          />
        </li>
        <li>
          <label for="postalCode">Postal Code</label>
          <input
            type="text"
            id="postalCode"
            v-model="customer.address.postalCode"
          />
        </li>
        <li>
          <label for="country">Country</label>
          <input
            type="text"
            id="country"
            v-model="customer.address.country"
          />
        </li>
      </ul>
    </template>
    <template v-slot:footer>
      <app-button
        type="button"
        @button:click="save"
        aria-label="save new customer"
      >
        Save Customer
      </app-button>

      <app-button
        type="button"
        @button:click="close"
        aria-label="Close modal"
      >
        Close
      </app-button>
    </template>
  </app-modal>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import AppButton from "@/components/AppButton.vue";
import AppModal from "@/components/AppModal.vue";
import { ICustomer } from "@/types/Customer";

@Component({
  name: "CustomerModal",
  components: { AppButton, AppModal }
})

export default class CustomerModal extends Vue {
  customer: ICustomer = {
    address: {},
    dateCreated: new Date(),
    dateUpdated: new Date(),
    firstName: "",
    lastName: ""
  };

  save() {
    this.$emit("save:customer", this.customer);
  }

  close() {
    this.$emit("close");
  }
}
</script>

<style scoped lang="scss">
.newCustomer {
  display: flex;
  flex-wrap: wrap;
  list-style: none;
  padding: 0;
  margin: 0;
  input {
    width: 80%;
    height: 1.8rem;
    margin: 0.8rem 2rem 0.8rem 0.8rem;
    font-size: 1.1rem;
    line-height: 1.3rem;
    padding: 0.2rem;
    color: #555;
  }
  label {
    font-weight: bold;
    display: block;
    margin-bottom: 0.3rem;
    color: rgb(37, 33, 33);
  }
}
</style>