export class ItemListModel {
    itemId: number | null;
    vendorId: number | null;
    acceptDays: number | null;
    isTaxable: boolean | null;
    itemCode: string;
    itemName: string;
    publicPrice: number | null;
    clientPrice: number | null;
    discount: number | null;
    isLocal: boolean | null;
    isActive: boolean | null;
    displayOrder: number | null;
    color: string;
    icon: string;
    unitId:number;
    
    isNewAdded: boolean | null;
    hasPromotion: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    isNewStocked: boolean | null;
    vendorGroupId: number | null;
    vendorName: string;
    itemGroupId: number | null;
    itemGroupName: string;
    quantity:number;
    quota:number;
}