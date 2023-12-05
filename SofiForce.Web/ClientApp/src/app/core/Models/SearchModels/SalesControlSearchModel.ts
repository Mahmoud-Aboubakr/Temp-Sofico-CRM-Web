
import { BaseSearchModel } from "./baseSearchModel";

export interface SalesControlSearchModel extends BaseSearchModel {
    branchId:number | 0;
    branchCode:string;

    supervisorId:number | 0;
    supervisorCode:string;

    representativeId:number | 0;
    representativeCode:string;

    clientId:number | 0;
    clientCode:string;
    
    fromDate:Date;
    toDate:Date;
}