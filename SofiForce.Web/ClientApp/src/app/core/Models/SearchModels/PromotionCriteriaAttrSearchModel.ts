import { BaseSearchModel } from "./baseSearchModel";

export interface PromotionCriteriaAttrSearchModel extends BaseSearchModel {
    isActive: number | null;
    isCustom: number | null;

    
}