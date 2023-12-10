import { BooleanModel } from "../DtoModels/BooleanModel";

export class SalesOrderAddressModel {
    salesAddressId: number;
    salesId: number | null;
    regionId: number | null;
    governerateId: number | null;
    cityId: number | null;
    address: string;
    landmark: string;
    latitude: number | null;
    longitude: number | null;
    building: string;
    floor: string;
    property: string;
    mobile: string;
    whatsApp: string;
    phone: string;
    updateClient:boolean;
}