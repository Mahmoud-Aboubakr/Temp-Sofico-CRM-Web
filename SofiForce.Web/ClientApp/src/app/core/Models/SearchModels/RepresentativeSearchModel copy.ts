
import { BranchModel } from "../EntityModels/branchModel";
import { SupervisorModel } from "../EntityModels/supervisorModel";
import { BaseSearchModel } from "./baseSearchModel";

export interface RepresentativeSearchModel extends BaseSearchModel {
    supervisorId: number;
    supervisorCode: string;
    branchId: number;
    branchCode: string;
    representativeName: string;
    terminationDate: Date;
    joinDate: Date;
    phone: string;
    kindId:0;
    kindIds:string;
    isActive:number;
    isTerminated:number;
    terminationReasonId:number;
    searchMode:number;

}