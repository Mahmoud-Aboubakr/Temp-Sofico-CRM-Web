export interface PromtionCriteriaSalesManModel {
    salesManCriteriaId: number;
    promotionId: number | null;
    salesManAttributeId: number | null;
    salesManAttributeCode: string | null;

    valueFrom: string;

    excluded: boolean | null;
    isActive: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}