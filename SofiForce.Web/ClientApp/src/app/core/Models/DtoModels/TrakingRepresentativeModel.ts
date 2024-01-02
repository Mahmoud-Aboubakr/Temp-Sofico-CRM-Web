export class TrakingRepresentativeModel {
    representativeId: number;
    representativeCode: string;
    representativeName: string;
    latitude: number | null;
    longitude: number | null;
    lastTraking: Date | null;
    isOnline: boolean | null;
}