export interface PromotionInputModel {
    promotionInputId: number;
    promotionInputCode: string;
    promotionInputNameEn: string;
    promotionInputNameAr: string;
    icon: string;
    color: string;
    displayOrder: number | null;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}