import { BaseSearchModel } from "./baseSearchModel";

export interface PromtionCriteriaClientAttrSearchModel extends BaseSearchModel {
    isActive: number | null;
    isCustom: number | null;
}