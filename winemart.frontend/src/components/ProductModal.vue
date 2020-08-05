<template>
    <app-modal>
        <template v-slot:header>
            Add Product
        </template>
        <template v-slot:body>
            <ul class="newProduct">
            <li class="tax-detail">
            <label for="isTaxable">Is this product taxable ?</label>
            <input
                type="checkbox"
                id="isTaxable"
                v-model="newProduct.isTaxable"
            />
            </li>
            <li>
            <label for="productName">Name</label>
            <input type="text" id="productName" v-model="newProduct.name" />
            </li>

            <li>
            <label for="productDesc">Description</label>
            <input
                type="text"
                id="productDesc"
                v-model="newProduct.description"
            />
            </li>

            <li>
            <label for="productPrice">Price (USD)</label>
            <input type="number" id="productPrice" v-model="newProduct.price" />
            </li>
        </ul>
        </template>
        <template v-slot:footer>
            <app-button
            type="button"
            @click.native="save"
            aria-label="save"
        >
            Save Product
        </app-button>
        <app-button
            type="button"
            @click.native="close"
            aria-label="close"
        >
            Close
        </app-button>
        </template>
    </app-modal>
</template>

<script lang="ts">
import Vue from 'vue';
import {Component, Prop} from 'vue-property-decorator';
import AppButton from '@/components/AppButton.vue'
import { IInventory } from '../types/Inventory';
import {IProduct} from '@/types/Product';
import AppModal from '@/components/AppModal.vue'

@Component({
    name: 'ProductModal',
    components: {AppButton, AppModal}
})

export default class ShipmentModal extends Vue {
    newProduct: IProduct = {
        id: 0,
        description: "",
        isTaxable: false,
        name: "",
        price: 0,
        isArchived: false,
        dateCreated: new Date(),
        dateUpdated: new Date()
  };

  qtyReceived: number = 0;

save() {
    this.$emit('save:product', this.newProduct);
  }

close() {
    this.$emit("close");
  }

}
</script>

<style lang="scss" scoped>
@import "@/scss/global.scss";

.newProduct {
  list-style: none;
  padding: 0;
  margin: 0;
  
  .tax-detail{
      display: flex;

      input{
          float: left;
          width: 10%;
          height: 1.3rem;
          padding: 0.1rem;
      }
  }

  input {
    width: 100%;
    height: 1.8rem;
    margin-bottom: 1.2rem;
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