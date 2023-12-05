export interface SupervisorListModel {
    supervisorId: number;
    supervisorCode: string;
    supervisorName: string;
    userId: number | null;
    businessUnitId: number | null;
    businessUnitCode: string;
    businessUnitName: string;
    companyCode: string;
    branchId: number | null;
    isActive: boolean | null;
    color: string;
    displayOrder: number | null;
    icon: string;
    canEdit: boolean | null;
    canDelete: boolean | null;
    branchCode: string;
    branchName: string;
    joinDate: Date | null;
    supervisorTypeName: string;
    notes: string;
    phone: string;
    phoneAlternative: string;
    isTerminated: boolean | null;
    terminationDate: Date | null;
    terminationReasonId: number | null;
    representatives: number | null;
}