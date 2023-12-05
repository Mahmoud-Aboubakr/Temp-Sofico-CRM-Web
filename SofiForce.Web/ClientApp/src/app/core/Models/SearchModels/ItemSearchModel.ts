import { BaseSearchModel } from "./baseSearchModel";

export interface ItemSearchModel extends BaseSearchModel {
    itemId: number | null;
    storeId: number | null;
    storeCode: string;
    vendorId: number | null;
    vendorCode:string;
    itemCode: string;
    itemName: string;
    isNewAdded: number;
    isNewStocked: number;
    hasPromotion: number;
    isActive: number;
    
    publicPrice:number;
    clientPrice:number;
}