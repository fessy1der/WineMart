  
import { IProduct } from "@/types/Product";

export interface IInvoice {
  customerId: number;
  lineItems: ILineItem[];
  dateCreated: Date;
  dateUpdated: Date;
}

export interface ILineItem {
  product?: IProduct;
  quantity: number;
}