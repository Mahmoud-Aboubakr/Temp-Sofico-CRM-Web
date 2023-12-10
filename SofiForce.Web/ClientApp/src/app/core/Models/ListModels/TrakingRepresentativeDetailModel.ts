export class TrakingRepresentativeDetailModel {
    trackingId: number;
    latitude: number | null;
    longitude: number | null;
    isPositive: boolean | null;
    inZone: boolean | null;
    distance: number | null;

    clientCode: string;
    clientName: string;
    trackTypeName: string;
    trackTypeId: number;
    salesId: number | null;
    clientId: number | null;
    trackTime:Date;
}