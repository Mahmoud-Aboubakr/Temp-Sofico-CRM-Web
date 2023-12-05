import { BaseSearchModel } from "./baseSearchModel";

export interface ItemQuotaSearchModel extends BaseSearchModel {
    itemId: number;
    itemCode: string;
}