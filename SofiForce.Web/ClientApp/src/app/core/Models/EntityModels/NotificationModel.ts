export interface NotificationModel {
    notificationId: number;
    notificationDate: Date | null;
    scheduleTime: Date | null;
    notificationDateTime: Date | null;
    priorityId: number | null;
    message: string;
    notificationTypeId: number | null;
    userGroupId: number;
    UserId: number;

}