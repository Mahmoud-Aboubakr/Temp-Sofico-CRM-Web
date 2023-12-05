export interface ClientPreferredTimeListModel {
    preferredId: number;
    clientId: number | null;
    preferredOperationId: number | null;
    weekDayId: number | null;
    fromTime: string | null;
    toTime: string | null;
    weekDayName: string;
    preferredOperationName: string;
}