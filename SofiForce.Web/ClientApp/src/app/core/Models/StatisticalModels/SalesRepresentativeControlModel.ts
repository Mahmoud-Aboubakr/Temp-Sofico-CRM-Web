export interface SalesRepresentativeControlModel {
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
    salesControlDetails: SalesRepresentativeControlDetailModel[];
}

export interface SalesRepresentativeControlDetailModel {
    supervisorId: number;
    branchCode: string;
    userId:number;
    representativeCode: string;
    representativeName: string;
    isActive:boolean;
    kindName: string;
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