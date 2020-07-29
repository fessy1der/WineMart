<template>
    <div class="link">
        <button @click="goToRoute">
            <slot></slot>
        </button>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import { Component } from 'vue-property-decorator';
import {Prop} from 'vue-property-decorator';

@Component({
    name: 'AppButton',
    components: {}
})

export default class AppButton extends Vue{
    @Prop({required: false, type: String}) 
    link?: string;

    goToRoute(){
        this.$router.push( this.link!);
    }
}
</script>

<style lang="scss" scoped>

</style>