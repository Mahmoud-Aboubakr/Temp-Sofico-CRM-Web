export interface SupervisorComissionListModel {
    comissionId: number | null;
    supervisorId: number | null;
    comissionDate: Date | null;
    comissionValue: number | null;
    isApproved: boolean | null;
    businessUnitId: number | null;
    supervisorTypeId: number | null;
    supervisorTypeCode: string;
    supervisorTypeName: string;
    companyCode: string;
    supervisorCode: string;
    supervisorName: string;
    branchId: number | null;
    branchName: string;
    branchCode: string;

    comissionTypeId: number | null;
    ComissionTypeName: string;
}

