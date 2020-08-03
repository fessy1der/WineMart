<template>
    <app-modal>
        <template v-slot:header>
            Add Shipment
        </template>
        <template v-slot:body>
            <label for="product">Product : </label>

            <select v-model="selectedProduct" class="shipmentItems" id="product">
                <option disabled value="">Please select one</option>
                <option v-for="item in inventory" :value="item" :key="item.product.id">{{ item.product.name }}</option>
            </select>

            <label for="qtyReceived">Quantity Received</label>
            <input type="number" id="qtyReceived" v-model="qtyReceived" />
        </template>
        <template v-slot:footer>
            <app-button
                type="button"
                @button:click="save"
                aria-label="save"
            >
                Save
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
import Vue from 'vue';
import {Component, Prop} from 'vue-property-decorator';
import AppButton from '@/components/AppButton.vue'
import { IInventory } from '../types/Inventory';
import {IProduct} from '@/types/Product';
import {IShipment} from '@/types/Shipment';

@Component({
    name: 'ShipmentModal',
    components: {AppButton}
})

export default class ShipmentModal extends Vue {
    @Prop({required: true, type: Array as () => IInventory[]})
    inventory! : IInventory[];

    selectedProduct: IProduct = {
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
    let shipment: IShipment = {
      productId: this.selectedProduct.id,
      adjustment: this.qtyReceived
    };
    this.$emit('save:shipment', shipment)
  }
}
</script>

<style lang="scss" scoped>

</style>