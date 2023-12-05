import { BaseSearchModel } from "./baseSearchModel";

export interface RepresentativeComissionSearchModel extends BaseSearchModel {
    supervisorId: number | null;
    supervisorCode: string;

    comissionDateFrom: Date | null;
    comissionDateTo: Date | null;
    isApproved: number | null;
    businessUnitId: number | null;
    kindId: number | null;
    comissionTypeId: number | null;
    branchId: number | null;
    branchCode: string;

}