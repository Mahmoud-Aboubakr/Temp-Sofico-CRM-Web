export interface OrderMonitorModel {
    all: number | null;
    rejected: number | null;

    confirmed: number | null;
    opened: number | null;
    transfered: number | null;
    invoiced: number | null;
    perormance: number;
    details: OrderMonitorDetailModel[];
}

export interface OrderMonitorDetailModel {
    branchId: number | null;
    serviceWorkerId:number| null;
    branchCode: string;
    branchName: string;
    confirmed: number | null;
    opened: number | null;
    all: number | null;
    rejected: number | null;
    transfered: number | null;
    invoiced: number | null;
    setupId: number | null;
    serviceWorkerCode: string;
    isEnabled: boolean | null;
    serviceWorkerName: string;
    perormance: number;
}