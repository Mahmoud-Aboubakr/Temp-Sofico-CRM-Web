export interface PromtionCriteriaSalesManAttrModel {
    salesManAttributeId: number;
    salesManAttributeCode: string;
    salesManAttributeNameAr: string;
    salesManAttributeNameEn: string;
    salesManAttributeDesc: string;
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