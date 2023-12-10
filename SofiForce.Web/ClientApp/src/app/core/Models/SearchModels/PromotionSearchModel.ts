import { BaseSearchModel } from "./baseSearchModel";

export class PromotionSearchModel extends BaseSearchModel {
    companyId: number;
    PromotionCategoryId: number | null;
    validFrom: Date | null;
    validTo: Date | null;
    isActive: number | null;
    isApproved: number | null;

    promotionTypeId: number | null;
    priority: number | null;
    repeats: number | null;
    promotionGroupId: number | null;
    repeatTypeId: number | null;

    displayOrder: number | null;
    enableNotification: number | null;
    notificationDate: Date | null;
    notificationDone: number | null;
    vendorCode:string;
}