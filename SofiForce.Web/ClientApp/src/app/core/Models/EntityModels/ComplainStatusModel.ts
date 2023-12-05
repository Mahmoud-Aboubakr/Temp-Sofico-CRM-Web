export interface ComplainStatusModel {
    complainStatusId: number;
    complainStatusCode: string;
    complainStatusNameAr: string;
    complainStatusNameEn: string;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    displayOrder: number | null;
    color: string;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}