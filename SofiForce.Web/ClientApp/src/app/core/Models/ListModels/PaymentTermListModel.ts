export interface PaymentTermListModel {
    paymentTermId: number;
    paymentTermCode: string;
    paymentTermName: string;
    icon: string;
    color: string;
    isActive: boolean | null;
    displayOrder: number | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
}