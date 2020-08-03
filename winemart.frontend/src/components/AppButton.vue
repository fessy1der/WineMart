<template>
    <div class="link">
        <button v-if="link" :class="['app-button', {'full-width': isFullWidth}]" @click="goToRoute" type="button">
            <slot></slot>
        </button>

        <button v-else :class="['app-button', {'full-width': isFullWidth}]" @click="onClick" type="button">
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

    @Prop({required: false, type: Boolean, default: false})
    isFullWidth?: boolean;

    goToRoute(){
        this.$router.push( this.link!);
    }

    onClick(){
      this.$emit('button:click');
    }
    
}
</script>

<style lang="scss" scoped>
@import "@/scss/global.scss";

.app-button {
  background: lighten($blue, 10%);
  color: white;
  padding: 0.8rem;
  transition: background-color 0.5s;
  margin: 0.3rem 0.2rem;
  display: inline-block;
  cursor: pointer;
  font-size: 1rem;
  font-weight: 700;
  min-width: 130px;
  border: none;
  border-bottom: 2px solid darken($blue, 20%);
  border-radius: 3px;
  &:hover {
    background: lighten($blue, 20%);
    transition: background-color 0.5s;
  }
  &:disabled {
    background: lighten($blue, 15%);
    border-bottom: 2px solid lighten($blue, 20%);
  }
  &:active {
    background: $primary;
    border-bottom: 2px solid lighten($yellow, 20%);
  }
}
.full-width {
  display: block;
  width: 100%;
}
</style>