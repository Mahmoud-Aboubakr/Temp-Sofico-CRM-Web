export interface PromotionGroupModel {
    promotionGroupId: number;
    promotionGroupCode: string;
    promotionGroupNameEn: string;
    promotionGroupNameAr: string;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    color: string;
    icon: string;
    displayOrder: number | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}