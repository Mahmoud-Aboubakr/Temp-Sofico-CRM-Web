import { BaseSearchModel } from "./baseSearchModel";

export interface PromotionTypeSearchModel extends BaseSearchModel {
    promotionInputId: number | null;
    promotionOutputId: number | null;
    isActive: number | null;
}