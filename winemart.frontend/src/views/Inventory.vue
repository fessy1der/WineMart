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
                    <div @click="archiveProduct(item.product.id)">
                        <i class="fas fa-archive"></i>
                    </div>
                </td>
            </tr>
        </table>    
        <product-modal v-if="isAddNewProduct" @save:product="saveNewProduct" @close="closeModals"/>
        <shipment-modal v-if="isAddNewShipment" @save:shipment="saveNewShipment" :inventory="inventory" @close="closeModals"/>
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
import { InventoryService } from '@/services/inventory-service'
import { ProductService } from '@/services/product-service'

const inventoryService = new InventoryService();
const productService = new ProductService();

@Component({
    name: 'Inventory',
    components: {AppButton, ProductModal, ShipmentModal}
})

export default class Inventory extends Vue{
    isAddNewProduct: boolean = false;
    isAddNewShipment: boolean = false;

    inventory: IInventory[] = [];

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
        await productService.save(newProduct);
        this.isAddNewProduct = false;
        await this.initialize();
    }

    async saveNewShipment(shipment: IShipment) {
        await inventoryService.updateInventoryQuantity(shipment);
        this.isAddNewShipment = false;
        await this.initialize();
    }

    async archiveProduct(productId: number){
        await productService.archive(productId);
        await this.initialize();
    }

    async initialize(){
        this.inventory = await inventoryService.getInventory();
        // await this.$store.dispatch("assignSnapshots")
    }

    async created(){
        await this.initialize();
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