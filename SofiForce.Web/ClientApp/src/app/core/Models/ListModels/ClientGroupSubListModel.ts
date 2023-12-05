
export interface ClientGroupSubListModel {
    clientGroupSubId: number;
    clientGroupId: number | null;
    clientGroupSubCode: string;
    clientGroupSubName: string;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    icon: string;
    color: string;
    displayOrder: number | null;

}