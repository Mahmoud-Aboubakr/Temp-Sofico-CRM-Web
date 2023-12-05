export interface BranchInvoiceingSetupListModel {
    setupId: number;
    branchId: number | null;
    branchCode: string | null;

    isEnabled: boolean | null;
    serviceWorkerId: number | null;
    serviceWorkerName: string | null;

}