import { AppUserModel } from "./appUserModel";

export interface AppUserLocationModel {
    trackingId: number;
    userId: number | null;
    trackingDate: Date | null;
    trackingTime: string | null;
    latitude: number | null;
    longitude: number | null;
    trackMode: number | null;

}