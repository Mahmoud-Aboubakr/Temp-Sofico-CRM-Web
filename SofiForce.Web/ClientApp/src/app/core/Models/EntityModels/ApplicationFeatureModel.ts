import { ApplicationModel } from "./applicationModel";
import { ApplicationFeaturePermissionModel } from "./applicationFeaturePermissionModel";
import { AppRoleFeatureModel } from "./appRoleFeatureModel";

export interface ApplicationFeatureModel {
    featueId: number;
    applicationId: number | null;
    featueCode: string;
    featueNameEn: string;
    featueNameAr: string;
    featuePath: string;
    icon: string;
    color: string;
    displyOrder: number | null;
    isActive: boolean | null;
    isNew: boolean | null;
    isUpdated: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

}