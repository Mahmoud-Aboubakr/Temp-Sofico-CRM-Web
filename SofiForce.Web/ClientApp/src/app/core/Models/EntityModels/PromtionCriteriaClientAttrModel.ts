export interface PromtionCriteriaClientAttrModel {
    clientAttributeId: number;
    clientAttributeCode: string;
    clientAttributeNameAr: string;
    clientAttributeNameEn: string;
    clientAttributeDesc: string;
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