import { StoreModel } from "./storeModel";

export interface StoreTypeModel {
    storeTypeId: number;
    storeTypeNameEn: string;
    storeTypeCode: string;
    storeTypeNameAr: string;
    isActive: boolean | null;
    displayOrder: number | null;
    icon: string;
    color: string;
    canEdit: boolean | null;
    canDelete: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
   
}