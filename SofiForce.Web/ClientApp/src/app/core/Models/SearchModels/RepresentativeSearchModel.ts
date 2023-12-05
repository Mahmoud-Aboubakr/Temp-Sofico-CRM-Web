import { BaseSearchModel } from "./baseSearchModel";

export interface RepresentativeSearchModel extends BaseSearchModel {
    supervisorId: number;
    supervisorCode:string;
    branchId: number;
    branchCode: string;

    kindId: number;
    kindIds: string;
    representativeName: string;
    terminationDate: Date | null;
    joinDate: Date | null;
    phone: string;
    isActive: number;
    isTerminated: number;
    terminationReasonId: number;
    businessUnitId: number;
    companyCode: string;
    searchMode:number;
}