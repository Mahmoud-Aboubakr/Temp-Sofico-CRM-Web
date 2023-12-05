import { BaseSearchModel } from "./baseSearchModel";

export interface ItemPromotionSearchModel extends BaseSearchModel {
    vendorId: number | null;
    vendorCode:string;
    itemId: number | null;
    itemCode:string;
    discount: number | null;
    validTo: Date | null;
    validFrom: Date | null;
}