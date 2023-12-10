export class ClientActivityListModel {
    activityId: number;
    clientId: number | null;
    activityTypeId: number | null;
    activityDate: Date | null;
    activityTime: Date | null;
    latitude: number | null;
    longitude: number | null;
    isPositive: boolean | null;
    clientCode: string;
    clientName: string;
    representativeId: number | null;
    duration: number | null;
    inJourney: boolean | null;
    distance: number | null;
    salesId: number | null;
    representativeCode: string;
    representativeName: string;
    branchCode: string;
    branchName: string;
    branchId: number | null;
    inZone: boolean | null;
    callAgain: Date | null;
}