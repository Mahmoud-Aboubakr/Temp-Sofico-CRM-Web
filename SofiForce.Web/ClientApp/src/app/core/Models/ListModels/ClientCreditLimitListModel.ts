export interface ClientCreditLimitListModel {
    limitId: number | null;
    clientId: number | null;
    limitYear: number | null;
    limitMonth: number | null;
    limitValue: number | null;
    clientCode: string;
    clientName: string;
    branchId: number | null;
    branchName: string;
    branchCode: string;
}