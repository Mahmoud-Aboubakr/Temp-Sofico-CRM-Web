export interface ServeyStatusModel {
    serveyStatusId: number;
    serveyStatusCode: string;
    serveyStatusNameEn: string;
    serveyStatusNameAr: string;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    displayOrder: number | null;
    color: string;
    icon: string;
}