import { BranchModel } from "../EntityModels/branchModel";
import { ClientModel } from "../EntityModels/clientModel";
import { RepresentativeModel } from "../EntityModels/representativeModel";
import { SupervisorModel } from "../EntityModels/supervisorModel";
import { BaseSearchModel } from "./baseSearchModel";

export interface MySalesPlanSearchModel extends BaseSearchModel {


    clientId:number | 0;
    clientCode:string;
    
    fromDate:Date;
    toDate:Date;
}