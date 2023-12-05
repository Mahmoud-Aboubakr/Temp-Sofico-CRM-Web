export interface ClientGroupListModel {
    clientGroupId: number;
    clientGroupCode: string;
    clientGroupName: string;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    icon: string;
    color: string;
    displayOrder: number | null;
}