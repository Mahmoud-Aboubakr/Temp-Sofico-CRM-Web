export class OperationRequestModel {
    operationId: number;
    operationCode: string;
    agentId: number | null;
    operationTypeId: number | null;
    governerateId: number | null;
    representativeId: number | null;
    representativecode:string |'';
    operationDate: Date | null;
    startDate: Date | null;
    targetDays: number | null;
    actualDays: number | null;
    targetClients: number | null;
    actualClients: number | null;
    daysPerformance: number | null;
    clientsPerformance: number | null;
    accuracy: number | null;
    mapPoints: string;
    isClosed: boolean | null;
    closeDate: Date | null;
    notes:string |null;
    cBy: number | null;
    eBy: number | null;
    cDate: Date | null;
    eDate: Date | null;
}