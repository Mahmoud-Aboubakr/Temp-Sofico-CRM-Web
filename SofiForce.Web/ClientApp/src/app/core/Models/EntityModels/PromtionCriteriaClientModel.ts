export interface PromtionCriteriaClientModel {
    clientCriteriaId: number;
    promotionId: number | null;
    clientAttributeId: number | null;
    clientAttributeCode: string | null;

    valueFrom: string;

    excluded: boolean | null;
    isActive: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}