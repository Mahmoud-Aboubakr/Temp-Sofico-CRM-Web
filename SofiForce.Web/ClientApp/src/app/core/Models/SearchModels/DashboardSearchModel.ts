import { BranchListModel } from "../ListModels/BranchListModel";
import { BaseSearchModel } from "./baseSearchModel";

export interface DashboardSearchModel {
    
    timePeriod:number,
    fromDate:Date,
    toDate:Date,
    branchs:BranchListModel[],
    channels:any[],
    lineChartMode:string;
    orderKBIMode:string;
    vendorId:number;
    itemId:number;
    representativeId:number;
    clientId:number;
    supervisorId:number;

    vendorCode:string;
    itemCode:string;
    representativeCode:string;
    clientCode:string;
    supervisorCode:string;
}
