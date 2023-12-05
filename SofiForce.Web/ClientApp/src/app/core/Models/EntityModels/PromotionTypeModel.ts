export interface PromotionTypeModel {
    promotionTypeId: number;
    promotionTypeCode: string;
    promotionTypeNameAr: string;
    promotionTypeNameEn: string;
    promotionTypeDesc: string;
    promotionInputId: number | null;
    promotionInputCode: string | null;

    promotionOutputId: number | null;
    promotionOutputCode: string | null;

    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    displayOrder: number | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}