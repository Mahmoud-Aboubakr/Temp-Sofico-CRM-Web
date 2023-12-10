export class PerformanceClientModel {
    targetValue: number | null;
    clientCoverage: number;
    clientAll:number;
    mySales: number | null;
    myOrders: number;
    targetCall: number;
    callAll: number;
    callNegative: number;
    callPostitive: number;
    targetVisit: number;
    visitAll: number;
    visitNegative: number;
    visitPostitive: number;
    salesPercentage: number;
    visitPercentage: number;
    callPercentage: number;
    perormancePercentage: number;
    perormanceLabel: string;
    detailModels: PerformanceClientDetailModel[];
}

export interface PerformanceClientDetailModel {
    isActive: boolean | null;
    clientId: number;
    routeId: number | null;
    routeCode: string;
    clientCode: string;
    clientName: string;
    targetValue: number | null;
    clientCoverage: number;
    mySales: number | null;
    myOrders: number;
    createDate: Date | null;
    targetCall: number;
    targetVisit: number;
    callAll: number;
    callInJourney: number;
    callInZone: number;
    callNegative: number;
    callPostitive: number;
    callOutJourney: number;
    callOutZone: number;
    visitAll: number;
    visitInJourney: number;
    visitInZone: number;
    visitNegative: number;
    visitPostitive: number;
    visitOutJourney: number;
    visitOutZone: number;
    salesPercentage: number;
    visitPercentage: number;
    callPercentage: number;
    perormancePercentage: number;
    perormanceLabel: string;
}