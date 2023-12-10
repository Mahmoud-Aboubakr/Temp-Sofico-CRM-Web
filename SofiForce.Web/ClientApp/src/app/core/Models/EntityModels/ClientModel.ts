import { ClientDocumentListModel } from "../ListModels/clientDocumentListModel";
import { ClientLandmarkListModel } from "../ListModels/ClientLandmarkListModel";
import { ClientPreferredTimeListModel } from "../ListModels/ClientPreferredTimeListModel";



export class ClientModel {
    clientId: number;
    clientAccountId: number | null;
    clientAccountCode: string | null;

    clientTypeId: number | null;
    clientCode: string;
    clientNameAr: string;
    clientNameEn: string;
    branchId: number | null;
    branchCode: string;


    regionId: number | null;
    governerateId: number | null;
    cityId: number | null;
    locationLevelId: number | null;
    clientGroupId: number | null;
    businessUnitId: number | null;
    clientGroupSubId: number | null;
    clientClassificationId: number | null;
    creditLimit: number | null;
    creditBalance: number | null;
    paymentTermId: number | null;
    isChain: boolean | null;
    responsibleNameAr: string;
    responsibleNameEn: string;
    building: string;
    floor: string;
    property: string;
    address: string;
    landmark: string;
    phone: string;
    mobile: string;
    whatsApp: string;
    isActive: boolean | null;
    latitude: number | null;
    longitude: number | null;
    taxCode: string;
    commercialCode: string;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
    isTaxable: boolean | null;
    isCashDiscount: boolean | null;
    documents: ClientDocumentListModel[];
    landmarks: ClientLandmarkListModel[];
    preferredTimes: ClientPreferredTimeListModel[];
}