export class RepresentativeComissionListModel {
    representativeId: number;
    representativeCode: string;
    representativeName: string;
    comissionId: number | null;
    supervisorId: number | null;
    comissionDate: Date | null;
    comissionValue: number | null;
    isApproved: boolean | null;
    businessUnitId: number | null;
    kindId: number | null;
    kindCode: string;
    kindName: string;
    companyCode: string;
    supervisorCode: string;
    supervisorName: string;
    branchId: number | null;
    branchName: string;
    branchCode: string;
    comissionTypeId: number | null;
    comissionTypeName: string;
}