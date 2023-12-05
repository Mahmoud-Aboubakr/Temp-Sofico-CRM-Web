export interface ClientClassificationListModel {
    clientClassificationId: number | null;
    clientClassificationCode: string;
    clientClassificationName: string;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    icon: string;
    color: string;
    displayOrder: number | null;
}