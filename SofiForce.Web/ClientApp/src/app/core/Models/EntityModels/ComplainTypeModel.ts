export interface ComplainTypeModel {
    complainTypeId: number;
    complainTypeCode: string;
    complainTypeNameAr: string;
    complainTypeNameEn: string;
    isActive: boolean | null;
    canDelete: boolean | null;
    canEdit: boolean | null;
    displayOrder: number | null;
    color: string;
    icon: string;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}