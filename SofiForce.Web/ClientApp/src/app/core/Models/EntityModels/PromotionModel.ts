export interface PromotionModel {
    promotionId: number;
    promotionCode: string;
    companyId: number;
    promotionCategoryId: number | null;
    validFrom: Date | null;
    validTo: Date | null;
    isActive: boolean | null;
    isApproved: boolean | null;
    promotionTypeId: number | null;
    priority: number | null;
    vendorCode: string | null;
    
    repeats: number | null;
    repeatTypeName:string;

    icon: string;
    color: string;
    promotionDesc: string;
    promotionGroupId: number | null;
    repeatTypeId: number | null;

    displayOrder: number | null;
    enableNotification: boolean | null;
    notificationDate: Date | null;
    notificationDone: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}