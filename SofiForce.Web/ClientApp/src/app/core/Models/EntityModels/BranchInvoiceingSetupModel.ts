export interface BranchInvoiceingSetupModel {
    setupId: number;
    branchId: number | null;
    isEnabled: boolean | null;
    serviceWorkerId: number | null;
}