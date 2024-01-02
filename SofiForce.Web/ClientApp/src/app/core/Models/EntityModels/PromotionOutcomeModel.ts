export class PromotionOutcomeModel {
    outcomeId: number;
    promotionId: number | null;
    isActive: boolean | null;
    count: number | null;
    displayOrder: number | null;
    itemCode: string;
    slice: number | null;
    value: number | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}