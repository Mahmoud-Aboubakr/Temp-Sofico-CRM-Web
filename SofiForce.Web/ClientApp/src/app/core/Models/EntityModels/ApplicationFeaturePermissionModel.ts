import { ApplicationFeatureModel } from "./applicationFeatureModel";
import { AppRoleFeaturePermissionModel } from "./appRoleFeaturePermissionModel";

export interface ApplicationFeaturePermissionModel {
    featurePermissionId: number;
    featueId: number | null;
    featurePermissionCode: string;
    featurePermissionNameEn: string;
    featurePermissionNameAr: string;
    icon: string;
    color: string;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

}