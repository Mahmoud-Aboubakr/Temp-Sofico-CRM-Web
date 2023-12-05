export interface NotificationDtoModel {
    notificationId: number;
    notificationDate: Date | null;
    scheduleTime: Date | null;
    notificationDateTime: Date | null;
    priorityName: string;
    message: string;
    notificationTypeName: string;
    notificationGroupName: string;
}