import { IProduct } from "@/types/Product";

export interface IInventory {
    id: number;
    product: IProduct;
    availableQuantity: number;
    supposedQuantity: number;
  }