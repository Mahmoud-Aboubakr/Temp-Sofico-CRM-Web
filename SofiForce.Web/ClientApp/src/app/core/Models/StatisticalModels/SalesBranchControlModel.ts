export interface SalesBranchControlModel {

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
    salesControlDetails: SalesBranchControlDetailModel[];

}

export interface SalesBranchControlDetailModel {
    branchId: number;
    branchCode: string;
    branchName: string;
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