export interface ClientServiceRequestTimlineListModel {
    timelineId: number;
    requestId: number | null;
    requestStatusId: number | null;
    userId: number | null;
    timelineDate: Date | null;
    notes: string;
    requestStatusName: string;
    realName: string;
    color: string;
}