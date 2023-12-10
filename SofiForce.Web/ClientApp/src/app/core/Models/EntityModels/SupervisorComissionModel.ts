export class SupervisorComissionModel {
    comissionId: number | null;
    supervisorId: number | null;
    supervisorCode: string | null;

    comissionDate: Date | null;
    comissionValue: number | null;
    isApproved: boolean | null;
    comissionTypeId: number | null;
    notes: string;
}