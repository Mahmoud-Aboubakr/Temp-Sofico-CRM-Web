export interface SalesSupervisorControlModel {
    clientCoverage: number;
    orders: number;
    salesDate: Date | null;
    salesDays: number;
    salesValue: number;
    clientAll: number;
    targetCall: number;
    targetValue: number;
    targetVisit: number;
    callAll: number;
    callNegative: number;
    callPostitive: number;
    visitAll: number;
    visitNegative: number;
    visitPostitive: number;
    salesPercentage: number;
    visitPercentage: number;
    callPercentage: number;
    perormancePercentage: number;
    perormanceLabel: string;
    salesControlDetails: SalesSupervisorControlDetailModel[];
}

export interface SalesSupervisorControlDetailModel {
    supervisorId: number;
    branchCode: string;
    userId:number;
    supervisorCode: string;
    supervisorName: string;
    supervisorTypeName: string;
    isActive:boolean;
    clientCoverage: number;
    orders: number;
    salesDate: Date | null;
    salesDays: number;
    salesValue: number;
    clientAll: number;
    targetCall: number;
    targetValue: number;
    targetVisit: number;
    callAll: number;
    callNegative: number;
    callPostitive: number;
    visitAll: number;
    visitNegative: number;
    visitPostitive: number;
    salesPercentage: number;
    visitPercentage: number;
    callPercentage: number;
    perormancePercentage: number;
    perormanceLabel: string;
}