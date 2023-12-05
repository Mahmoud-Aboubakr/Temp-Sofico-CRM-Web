import { BaseSearchModel } from "./baseSearchModel";

export interface VendorSearchModel extends BaseSearchModel {
    vendorGroupId: number | null;
}