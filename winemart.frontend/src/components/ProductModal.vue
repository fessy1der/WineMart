<template>
    <app-modal>
        <template v-slot:header>
            Add Product
        </template>
        <template v-slot:body>
            <ul class="newProduct">
            <li>
            <label for="isTaxable">Is this product taxable?</label>
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
            <solar-button
            type="button"
            @click.native="save"
            aria-label="save"
        >
            Save Product
        </solar-button>
        <solar-button
            type="button"
            @click.native="close"
            aria-label="close"
        >
            Close
        </solar-button>
        </template>
    </app-modal>
</template>

<script lang="ts">
import Vue from 'vue';
import {Component, Prop} from 'vue-property-decorator';
import AppButton from '@/components/AppButton.vue'
import { IInventory } from '../types/Inventory';
import {IProduct} from '@/types/Product';

@Component({
    name: 'ProductModal',
    components: {AppButton}
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

</style>