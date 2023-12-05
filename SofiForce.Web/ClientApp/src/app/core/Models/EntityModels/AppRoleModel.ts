import { AppRoleFeatureModel } from "./appRoleFeatureModel";
import { AppRoleUserModel } from "./appRoleUserModel";

export interface AppRoleModel {
    appRoleId: number;
    appRoleCode: string;
    appRoleNameEn: string;
    appRoleNameAr: string;
    icon: string;
    color: string;
    displayOrder: number | null;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

}