export interface KBISummeryModel {
    performanceValue: number;
    performanceLabel: string;
    salesTotal: number;
    salesTarget: number;
    salesP: number;
    visitTotal: number;
    visitTarget: number;
    visitP: number;
    callTotal: number;
    callTarget: number;
    callP: number;
    orders: number;
    clients: number;
    clientsTarget: number;
    clientsP: number;

    days: number;
    daysTarget: number;
    daysP: number;

    representativeId: number;
    representativeCode: string;
    representativeName: string;
    phone: string;
    lastTrackDate: Date | null;
    idealFor: number;

    firstOrder:Date;
    lastOrder:Date;
}