export interface SalesOrderDispatchModel {
    dispatchId: number;
    salesId: number | null;
    dispatchCode: string;
    dispatchDate: Date | null;
    dispatchTime: Date | null;
    shiftDate: Date | null;
    distributorId: number | null;
    carId: number | null;
    driverId: number | null;

    distributorCode: string | null;
    carCode: string | null;
    driverCode: string | null;


    inZone: boolean | null;
    distance: number | null;
    latitude: number | null;
    longitude: number | null;
    feedbackId: number | null;

    notes:string;
}