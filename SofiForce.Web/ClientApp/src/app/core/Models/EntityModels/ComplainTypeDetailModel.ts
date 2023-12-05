export interface ComplainTypeDetailModel {
    complainTypeDetailId: number;
    complainTypeId: number | null;
    complainTypeDetailCode: string;
    complainTypeDetailNameAr: string;
    complainTypeDetailNameEn: string;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    displayOrder: number | null;
    color: string;
    icon: string;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}