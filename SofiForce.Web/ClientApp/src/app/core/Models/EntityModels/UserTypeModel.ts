import { AppUserModel } from "./appUserModel";

export interface UserTypeModel {
    userTypeId: number;
    userTypeCode: string;
    userTypeNameEn: string;
    userTypeNameAr: string;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    displayOrder: number | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
 
}