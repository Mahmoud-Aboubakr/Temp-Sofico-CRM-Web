export class UserNotificationListModel {
    notificationId: number;
    readDate: Date | null;
    isReaded: boolean | null;
    message: string;
    priorityName: string;
    notificationTypeName: string;
    notificationDate: Date | null;
    priorityColor: string;
    userGroupName: string;
}