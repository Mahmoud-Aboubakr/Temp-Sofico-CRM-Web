import { BaseSearchModel } from "./baseSearchModel";

export interface ClientSearchModel extends BaseSearchModel {
    clientId: number | null;
    clientCode: string;
    clientName: string;
    clientTypeId: number | null;
    branchId: number | null;
    branchCode:string;
    branchSubId: number | null;
    regionId: number | null;
    governerateId: number | null;
    cityId: number | null;
    areaId: number | null;
    clientGroupId: number | null;
    clientGroupSubId: number | null;
    businessUnitId: number | null;
    inRoute: number | null;
    isNew: number;
    needValidation: number;
    phone: string;
    mobile: string;
    whatsApp: string;
    isActive: number | null;
    isTaxable: number | null;
    isChain: number | null;
    locationLevelId: number | null;
    clientClassificationId: number | null;
    paymentTermId: number | null;
    taxCode: string;
    commercialCode: string;
    building:string;

    floor:string;
    property:string;
}