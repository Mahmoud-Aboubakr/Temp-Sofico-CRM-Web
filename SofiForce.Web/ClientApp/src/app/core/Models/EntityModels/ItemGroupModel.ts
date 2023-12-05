import { ItemModel } from "./itemModel";

export interface ItemGroupModel {
    itemGroupId: string;
    itemGroupCode: string;
    itemGroupNameEn: string;
    itemGroupNameAr: string;
    icon: string;
    color: string;
    displayOrder: number | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    isActive: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

}