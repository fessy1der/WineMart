import axios from "axios";
import {IInventory} from "@/types/Inventory";
import {IShipment} from "@/types/Shipment";
import {IInventoryTimeline} from "@/types/Graph";


export class InventoryService {
  API_URL = process.env.VUE_APP_API_URL;

  public async getInventory(): Promise<IInventory[]> {
    let result = await axios.get(`${this.API_URL}/inventory/`);
    return result.data;
  }

  public async updateInventoryQuantity(shipment: IShipment) {
    let result = await axios.patch(`${this.API_URL}/inventory/`, shipment);
    return result.data;
  }

  public async getTrackingHistory(): Promise<IInventoryTimeline> {
    let result: any = await axios.get(`${this.API_URL}/inventory/snapshot`);
    return result.data;
  }
}