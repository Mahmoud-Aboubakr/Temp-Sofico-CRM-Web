export interface NotificationListModel {
    notificationId: number;
    notificationDate: Date | null;
    scheduleTime: Date | null;
    notificationDateTime: Date | null;
    priorityId: number | null;
    priorityName: string;
    message: string;
    notificationTypeId: number | null;
    notificationTypeName: string;
    notificationGroupId: number | null;
    notificationGroupName: string;
    priorityColor:string;
    performance:number;
}