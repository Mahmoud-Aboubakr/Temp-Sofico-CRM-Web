export class BusinessUnitModel {
    businessUnitId: number | null;
    branchId: number | null;
    branchCode: string | null;

    businessUnitCode: string;
    businessUnitNameAr: string;
    businessUnitNameEn: string;
    icon: string;
    color: string;
    displayOrder: number | null;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    notes: string;
}