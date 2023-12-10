export class ClientComplainListModel {
    complainId: number;
    complainCode: string;
    branchId: number | null;
    representativeId: number | null;
    clientId: number | null;
    complainDate: Date | null;
    complainTime: Date | null;
    complainTypeId: number | null;
    phone: string;
    priorityId: number | null;
    complainStatusId: number | null;
    isClosed: boolean | null;
    closeDate: Date | null;
    duration: number | null;
    departmentId: number | null;
    priorityName: string;
    complainTypeName: string;
    branchName: string;
    clientCode: string;
    clientName: string;
    branchCode: string;
    departmentName: string;
    complainStatusName: string;
    representativeName: string;
    representativeCode: string;
    complainTypeDetailId: number | null;
}