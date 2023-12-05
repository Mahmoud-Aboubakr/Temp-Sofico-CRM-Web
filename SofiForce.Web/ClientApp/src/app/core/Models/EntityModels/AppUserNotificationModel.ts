import { AppUserModel } from "./appUserModel";

export interface AppUserNotificationModel {
    userNotificationId: number;
    notificationId: number;
    userId: number;
    readDate: Date | null;
    isReaded: boolean | null;

}