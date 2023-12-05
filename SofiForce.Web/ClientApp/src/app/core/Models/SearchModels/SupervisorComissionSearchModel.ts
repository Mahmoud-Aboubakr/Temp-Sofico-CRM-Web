import { BaseSearchModel } from "./baseSearchModel";

export interface SupervisorComissionSearchModel extends BaseSearchModel {
    supervisorId: number | null;
    supervisorCode: string | null;

    comissionDateFrom: Date | null;
    comissionDateTo: Date | null;
    isApproved: number | null;
    businessUnitId: number | null;
    supervisorTypeId: number | null;
    comissionTypeId: number | null;

    
    branchId: number | null;
    branchCode: string | null;

}