import { BaseSearchModel } from "./baseSearchModel";

export interface SalesMonitorSearchModel extends BaseSearchModel {
    branchId: number;
    branchCode:string;
}