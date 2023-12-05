export interface ClientPlanUploadModel {
    planYear: number;
    planMonth: number;
    filePath: string;
    uploadDate: Date | null;
    clearCurrent: boolean | false;
}