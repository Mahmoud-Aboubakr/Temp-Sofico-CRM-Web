import { BaseSearchModel } from "./baseSearchModel";

export interface ExportSearchModel extends BaseSearchModel {
    fromDate: Date | null;
    toDate: Date | null;
    clientId: number | null;
    clientCode: string;
    branchId: number | null;
    branchCode: string;
    storeId: number | null;
    storeCode: string;
    vendorId: number | null;
    vendorCode: string;
    itemId: number | null;
    itemCode: string;

    representativeId:number |null;
    representativeCode:string |null;

}