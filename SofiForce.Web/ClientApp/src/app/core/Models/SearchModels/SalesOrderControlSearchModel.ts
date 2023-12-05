import { BaseSearchModel } from "./baseSearchModel";

export interface SalesOrderControlSearchModel extends BaseSearchModel {
    clientId: number | null;
    salesCode: string;
    clientCode: string;
    branchId: number | null;
    branchCode:string;
    representativeId: number | null;
    representativeCode: string | null;

    storeId: number | null;
    storeCode: string;

    priorityTypeId: number | null;
    salesDateFrom: Date | null;
    salesDateTo: Date | null;
    salesOrderTypeId: number | null;
    salesOrderStatusId: number | null;
    rejectedOnly: number | null;
}