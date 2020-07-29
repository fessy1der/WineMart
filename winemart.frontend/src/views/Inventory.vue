<template>
    <div class="container">
        <h1 id="title">Dashboard</h1>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import { Component } from 'vue-property-decorator';

@Component({
    name: 'Inventory',
    components: {}
})

export default class Inventory extends Vue{}

</script>

<style lang="scss" scoped>
@import "@/scss/global.scss";

</style>