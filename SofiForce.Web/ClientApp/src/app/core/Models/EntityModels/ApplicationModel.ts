import { ApplicationFeatureModel } from "./applicationFeatureModel";
import { ApplicationSettingModel } from "./applicationSettingModel";

export interface ApplicationModel {
    applicationId: number;
    applicationCode: string;
    applicationNameEn: string;
    applicationNameAr: string;
    color: string;
    icon: string;
    displayOrder: number | null;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

}