export interface ClientBasicDto {
    clientId: number;
    clientAccountId: number | null;
    clientAccountCode: string;
    clientTypeId: number | null;
    clientCode: string;
    clientNameAr: string;
    clientNameEn: string;
    branchId: number | null;
    regionId: number | null;
    clientGroupId: number | null;
    clientGroupSubId: number | null;
    businessUnitId: number | null;
    clientClassificationId: number | null;
    creditLimit: number | null;
    creditBalance: number | null;
    paymentTermId: number | null;
    isChain: boolean | null;
    responsibleNameAr: string;
    responsibleNameEn: string;
    isTaxable: boolean | null;
    isActive: boolean | null;
    isCashDiscount: boolean | null;
    taxCode: string;
    commercialCode: string;
}