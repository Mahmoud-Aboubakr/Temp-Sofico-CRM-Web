import { BranchModel } from "../EntityModels/branchModel";
import { ClientModel } from "../EntityModels/clientModel";
import { RepresentativeModel } from "../EntityModels/representativeModel";
import { SupervisorModel } from "../EntityModels/supervisorModel";
import { BaseSearchModel } from "./baseSearchModel";

export interface GPSTrackingDetailSearchModel extends BaseSearchModel {

    representativeId:number | 0;
    trackingDate:Date;

}