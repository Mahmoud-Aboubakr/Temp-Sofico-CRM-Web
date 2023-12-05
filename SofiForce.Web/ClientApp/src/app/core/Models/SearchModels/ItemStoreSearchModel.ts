import { BaseSearchModel } from "./baseSearchModel";

export interface ItemStoreSearchModel extends BaseSearchModel {
    vendorId: number | null;
    itemId: number | null;
    branchId: number | null;
    storeId: number | null;
    expireDate:Date;
    isActive:number;
    available:number;
}