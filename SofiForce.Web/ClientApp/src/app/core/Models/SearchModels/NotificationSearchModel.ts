import { BaseSearchModel } from "./baseSearchModel";

export interface NotificationSearchModel extends BaseSearchModel {
    notificationDate: Date | null;
    priorityId: number | null;
    notificationTypeId: number | null;
    userGroupId: number | null;
    isReaded:number;
}