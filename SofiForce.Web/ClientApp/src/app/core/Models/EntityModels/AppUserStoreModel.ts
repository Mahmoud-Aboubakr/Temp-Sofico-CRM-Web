import { AppUserModel } from "./appUserModel";
import { StoreModel } from "./storeModel";

export interface AppUserStoreModel {
    appUserStoreId: number;
    userId: number | null;
    storeId: number | null;

}