export interface PromotionCriteriaModel {
    criteriaId: number;

    promotionId: number | null;
    groupId: number | null;
    groupCode: string;

    attributeId: number | null;
    attributeCode: string | null;

    valueFrom: string;

    isActive: boolean | null;
    excluded: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}