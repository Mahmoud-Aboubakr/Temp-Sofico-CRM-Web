import { ApplicationModel } from "./applicationModel";

export interface ApplicationSettingModel {
    appSettingId: number;
    applicationId: number | null;
    appSettingCode: string;
    appSettingName: string;
    appSettingValue: string;
    appSettingLastDate: Date | null;

}