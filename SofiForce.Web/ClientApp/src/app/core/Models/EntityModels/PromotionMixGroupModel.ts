export class PromotionMixGroupModel {
    groupId: number;
    groupNo: number;

    promotionId: number | null;
    slice: number | null;
    isActive: boolean | null;

    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}