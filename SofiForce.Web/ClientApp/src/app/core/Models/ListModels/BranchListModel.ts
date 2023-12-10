export class BranchListModel {
    branchId: number;
    branchName: string;
    branchCode: string;
    isActive: boolean | null;
    color: string;
    icon: string;
    displayOrder: number | null;
    expenseRate: number | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    latitude: number | null;
    longitude: number | null;
}