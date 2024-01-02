export class ClientActivityModel {
    activityId: number;
    clientId: number | null;
    clientCode: string | '';
    representativeId: number | null;
    representativeCode: string | '';
    activityDate: Date | null;
    activityTime: Date | null;
    callAgain: Date | null;

    inJourney: boolean | null;
    inZone: boolean | null;

    isPositive: boolean | null;
    activityTypeId: number | null;
    latitude: number | null;
    longitude: number | null;
    duration:number;
    distance:number;

    notes: string | '';

    salesId:number;


}