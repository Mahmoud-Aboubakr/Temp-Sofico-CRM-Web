export interface BusinessUnitListModel {
    businessUnitId: number | null;
    branchId: number | null;
    businessUnitCode: string;
    businessUnitName: string;
    icon: string;
    color: string;
    displayOrder: number | null;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    branchCode: string;
    branchName: string;
}