export class PerformanceSalesmanModel {
    representativeId: number;
    supervisorId: number | null;
    branchId: number;
    isActive:boolean;
    branchCode: string;
    companyCode: string;
    representativeCode: string;
    routeId: number | null;
    routeCode: string;
    kindName: string;
    representativeName: string;
    routeSales: number;
    clientCoverage: number;
    targetValue: number;
    targetCall: number;
    targetVisit: number;
    routeClient: number;
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
    mySales: number;
    myOrders: number;
    salesPercentage: number;
    visitPercentage: number;
    callPercentage: number;
    perormancePercentage: number;
    perormanceLabel: string;
}