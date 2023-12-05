export interface SalesOrderMessagesListModel {
    salesMessageId: number | null;
    salesId: number | null;
    userId: number | null;
    messageDate: Date | null;
    message: string;
    realName: string;
    userName: string;
    avatar: string;
    jobTitle: string;
}