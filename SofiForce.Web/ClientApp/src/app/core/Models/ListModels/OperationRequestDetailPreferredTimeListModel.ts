export interface OperationRequestDetailPreferredTimeListModel {
    preferredId: number;
    detailId: number | null;
    preferredOperationId: number | null;
    weekDayId: number | null;
    fromTime: string | null;
    toTime: string | null;
    weekDayName: string;
    preferredOperationName: string;
}