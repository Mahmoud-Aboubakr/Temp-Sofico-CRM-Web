import { BaseSearchModel } from "./baseSearchModel";

export interface SupervisorSearchModel extends BaseSearchModel {
    branchId: number;
    branchCode: string;
    supervisorTypeId: number;
    supervisorTypeIds: string;
    supervisorName: string;
    terminationDate: Date | null;
    joinDate: Date | null;
    phone: string;
    isActive: number;
    isTerminated: number;
    terminationReasonId: number;
    businessUnitId: number;
    companyCode: string;
}