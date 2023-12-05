export interface ServeyGroupModel {
    serveyGroupId: number;
    serveyGroupCode: string;
    serveyGroupNameEn: string;
    serveyGroupNameAr: string;
    isActive: number | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    displayOrder: number | null;
    color: string;
    icon: string;
}