export interface PromotionCriteriaAttrModel {
    attributeId: number;
    attributeCode: string;
    attributeNameAr: string;
    attributeNameEn: string;
    attributeNameDesc: string;
    isCustom: boolean | null;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    displayOrder: number | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}