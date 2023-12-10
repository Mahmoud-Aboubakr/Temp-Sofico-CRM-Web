export class OperationRequestListModel {
    operationId: number | null;
    operationCode: string;
    agentId: number | null;
    operationTypeId: number | null;
    representativeId: number | null;
    startDate: Date | null;
    targetDays: number | null;
    isClosed: boolean | null;
    closeDate: Date | null;
    representativeCode: string;
    representativeName: string;
    operationTypeName: string;
    phone: string;
    operationDate: Date | null;
    accuracy: number | null;
    clientsPerformance: number | null;
    daysPerformance: number | null;
    actualClients: number | null;
    targetClients: number | null;
    actualDays: number | null;
}