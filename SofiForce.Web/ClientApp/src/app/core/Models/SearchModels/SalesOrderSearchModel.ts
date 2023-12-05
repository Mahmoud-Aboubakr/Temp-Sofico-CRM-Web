import { BranchModel } from "../EntityModels/branchModel";
import { RepresentativeModel } from "../EntityModels/representativeModel";
import { StoreModel } from "../EntityModels/storeModel";
import { BaseSearchModel } from "./baseSearchModel";

export interface SalesOrderSearchModel extends BaseSearchModel {
    salesCode: string;
    clientId:number;
    clientCode: string;
    branchId: number | null;
    branchCode: string | null;
    representativeId: number | null;
    representativeCode:string|null;
    storeId: number | null;
    storeCode: string | null;
    priorityTypeId: number | null;
    salesDate: Date | null;
    salesOrderStatusId: number;
    salesOrderTypeId:number;
    salesOrderSourceId:number [];
    invoiceDate: Date | null;
    isInvoiced:number;
    filterMode:number | 1;
    cashDiscountOnly:boolean |0;
}