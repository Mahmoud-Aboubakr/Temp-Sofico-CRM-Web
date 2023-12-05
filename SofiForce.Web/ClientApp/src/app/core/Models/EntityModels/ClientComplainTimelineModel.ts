export interface ClientComplainTimelineListModel {
    timelineId: number;
    complainId: number | null;
    complainStatusId: number | null;
    complainStatusName: string;
    userId: number | null;
    timelineDate: Date | null;
    notes: string;
    userName:string;
}