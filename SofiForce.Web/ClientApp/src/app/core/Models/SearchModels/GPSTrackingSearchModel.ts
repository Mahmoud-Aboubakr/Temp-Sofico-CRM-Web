import { BranchModel } from "../EntityModels/branchModel";
import { ClientModel } from "../EntityModels/clientModel";
import { RepresentativeModel } from "../EntityModels/representativeModel";
import { SupervisorModel } from "../EntityModels/supervisorModel";
import { BaseSearchModel } from "./baseSearchModel";

export interface GPSTrackingSearchModel extends BaseSearchModel {
    branchId:number | 0;
    branchCode:string;

    supervisorId:number | 0;
    supervisorCode:string;

    representativeId:number | 0;
    representativeKindId:number | 0;
    statusId :number |0,
    representativeCode:string;

}