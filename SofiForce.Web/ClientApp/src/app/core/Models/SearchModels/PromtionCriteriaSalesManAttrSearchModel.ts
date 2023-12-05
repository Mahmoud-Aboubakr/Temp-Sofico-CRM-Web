import { BaseSearchModel } from "./baseSearchModel";

export interface PromtionCriteriaSalesManAttrSearchModel extends BaseSearchModel {
    isActive: number | null;
    isCustom: number | null;
}