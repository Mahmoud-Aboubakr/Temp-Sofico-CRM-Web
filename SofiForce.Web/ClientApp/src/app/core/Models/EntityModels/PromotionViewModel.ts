export interface PromotionViewModel {
    conditionTypeID: string;
    promotionInput: number | null;
    promotionOutput: number | null;
    promotionInputName: number | null;
    promotionOutputName: number | null;
    description: string;
    PromotionCategoryId: number;
    prioritycode: string;
    priorityvalue: number | null;
    promotionid: string;
    promotionorderstatus: boolean | null;
    repeatsNo: number | null;
    validfrom: Date | null;
    validto: Date | null;
    promotionItemCritria: PromotionItemCritriaViewModel[];
    promotionMixAndMatchGroup: PromotionMixAndMatchGroupViewModel[];
    promotionOutcome: PromotionOutcomeViewModel[];
    promotionClient: PromotionClientViewModel[];
    promotionHistory: PromotionHistoryViewModel[];
}

export interface PromotionItemCritriaViewModel {
    exclude: boolean;
    groupNo: number | null;
    itemCode: string;
    itemName: string;
    promotionId: string;
    groupSlice:number;
}

export interface PromotionMixAndMatchGroupViewModel {
    promotionId: string;
    groupNo: number | null;
    slice: number | null;
}

export interface PromotionOutcomeViewModel {
    promotionId: string;
    count: number | null;
    itemCode: string;
    itemName: string;
    option: number | null;
    percentage: number | null;
    quantity: number | null;
    slice: number | null;
    value: number | null;
}

export interface PromotionClientViewModel {
    promotionId: string;
    clientCode: string;
    exclude: boolean;
}

export interface PromotionHistoryViewModel {
    promotionId: string;
    salesCode: string;
    clientCode: string;
}