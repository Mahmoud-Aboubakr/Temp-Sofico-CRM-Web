export interface RequestTypeDetailModel {
    requestTypeDetailId: number;
    requestTypeId: number | null;
    requestTypeDetailCode: string;
    requestTypeDetailNameEn: string;
    requestTypeDetailNameAr: string;
    icon: string;
    color: string;
    displayOrder: number | null;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}