import { BaseSearchModel } from "./baseSearchModel";

export interface ItemStoreTotalSearchModel extends BaseSearchModel {
    vendorId: number | null;
    vendorCode: string | null;

    itemId: number | null;
    itemCode: string | null;

    branchId: number | null;
    branchCode: string | null;

    storeId: number | null;
    storeCode: string | null;

}