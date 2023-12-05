export interface SyncSetupDetailModel {
    detailId: number | null;
    setupId: number | null;
    userId: number | null;
    syncDate: Date | null;
    payload1: string;
    payload2: string;
    payload3: string;
    payload4: string;
    isDone: boolean | null;
    inprogress: boolean | null;
    message: string;
}