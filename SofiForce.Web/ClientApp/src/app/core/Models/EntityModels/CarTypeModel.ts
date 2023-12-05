export interface CarTypeModel {
    carTypeId: number;
    carTypeCode: string;
    carTypeNameEn: string;
    carTypeNameAr: string;
    displayOrder: number | null;
    isActive: boolean | null;
    color: string;
    icon: string;
    canEdit: boolean | null;
    canDelete: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}