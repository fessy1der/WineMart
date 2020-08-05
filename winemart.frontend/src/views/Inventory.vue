<template>
    <div class="container">
        <h1 id="title">Dashboard</h1>
        <hr>

        <div class="actions">
            <app-button @button:click="displayProductModal" id="btnAddProduct" > Add Product </app-button>
            <app-button @button:click="displayShipmentModal" id="btnAddShipment" > Add Shipment </app-button>
        </div>

        <table id="tbl" class="tbl">
            <tr>
                <th>Product Name</th>
                <th>Price per item</th>
                <th>Available Quantity</th>
                <th>Supposed Quantity</th>
               <th>Delete</th>
            </tr>
            <tr v-for="item in inventory" :key="item.id">
                <td>
                    {{ item.product.name }}
                </td>
                <td>
                    {{ item.product.price | price }}
                </td>
                <td>
                    {{ item.availableQuantity }}
                </td>
                <td>
                    {{ item.supposedQuantity }}
                </td>
                <td>
                    <div>
                        <i class="fas fa-trash-alt"></i>
                    </div>
                </td>
            </tr>
        </table>    
        <product-modal v-if="isAddNewProduct" @close="closeModals"/>
        <shipment-modal v-if="isAddNewShipment" :inventory="inventory" @close="closeModals"/>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import { Component } from 'vue-property-decorator';
import {IInventory} from '@/types/Inventory'
import {IShipment} from '@/types/Shipment'
import {IProduct} from '@/types/Product'
import AppButton from '@/components/AppButton.vue'
import ProductModal from '@/components/ProductModal.vue'
import ShipmentModal from '@/components/ShipmentModal.vue'

@Component({
    name: 'Inventory',
    components: {AppButton, ProductModal, ShipmentModal}
})

export default class Inventory extends Vue{
    isAddNewProduct: boolean = false;
    isAddNewShipment: boolean = false;

    inventory: IInventory[] = [
        {
            id: 1,
            product: {
                id: 1,
                name: "test",
                description: "anything",
                price: 20,
                isTaxable: true,
                isArchived: false,
                dateCreated: new Date(),
                dateUpdated: new Date()
            },
            availableQuantity: 35,
            supposedQuantity: 35,
        },
        {
            id: 2,
            product: {
                id: 2,
                name: "test 2",
                description: "any product",
                price: 40,
                isTaxable: true,
                isArchived: false,
                dateCreated: new Date(),
                dateUpdated: new Date()
            },
            availableQuantity: 45,
            supposedQuantity: 45,
        }
    ];

    displayProductModal(){
        this.isAddNewProduct = true;
    }

    displayShipmentModal(){
        this.isAddNewShipment = true;
    }

    closeModals(){
        this.isAddNewShipment = false;
        this.isAddNewProduct = false;
    }

    async saveNewProduct(newProduct: IProduct) {
    
    }

    async saveNewShipment(shipment: IShipment) {
        
    }

    async initialize(){

    }

    async created(){
        
    }
}

</script>

<style lang="scss" scoped>
@import "@/scss/global.scss";

.actions{
    display: flex;
    float: right;
    margin-bottom: 15px;
}
</style>