import { BaseSearchModel } from "./baseSearchModel";

export interface ItemPromotionAllSearchModel extends BaseSearchModel {
    itemId: number;
    promotionId: number;
    isActive: number;
    promotionCode: string;
    itemCode: string;
}