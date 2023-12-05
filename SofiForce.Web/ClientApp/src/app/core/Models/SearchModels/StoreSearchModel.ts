
import { BranchModel } from "../EntityModels/branchModel";
import { StoreTypeModel } from "../EntityModels/storeTypeModel";
import { BaseSearchModel } from "./baseSearchModel";

export interface StoreSearchModel extends BaseSearchModel {
    branchId: number | null;
    branchCode: string;
    storeTypeId: number | null;
    isActive: number | null;
    isOrder: number | null;

    storeMode:number;

}