export interface ClientServiceRequestTimlineModel {
    timelineId: number;
    requestId: number | null;
    requestStatusId: number | null;
    userId: number | null;
    timelineDate: Date | null;
    notes: string;
}