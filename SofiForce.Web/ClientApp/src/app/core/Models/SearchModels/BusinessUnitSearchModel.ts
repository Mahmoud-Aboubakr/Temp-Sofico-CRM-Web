import { BaseSearchModel } from "./baseSearchModel";

export interface BusinessUnitSearchModel extends BaseSearchModel {
    branchId: number | null;
}