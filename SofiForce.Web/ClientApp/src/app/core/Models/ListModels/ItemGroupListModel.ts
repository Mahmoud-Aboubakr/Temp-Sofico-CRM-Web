export class ItemGroupListModel {
    itemGroupId: string;
    itemGroupCode: string;
    itemGroupName: string;
    icon: string;
    color: string;
    displayOrder: number | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    isActive: boolean | null;
}