import { OperationRequestDetailDocumentListModel } from "../ListModels/OperationRequestDetailDocumentListModel";
import { OperationRequestDetailLandmarkListModel } from "../ListModels/OperationRequestDetailLandmarkListModel";
import { OperationRequestDetailPreferredTimeListModel } from "../ListModels/OperationRequestDetailPreferredTimeListModel";


export class OperationRequestDetailModel {
    detailId: number;
    operationTypeId:number;
    operationId: number | null;
    operationDate: Date | null;
    clientId: number | null;
    clientCode: string | null;

    clientTypeId: number | null;
    clientNameAr: string;
    clientNameEn: string;
    regionId: number | null;
    governerateId: number | null;
    cityId: number | null;
    locationLevelId: number | null;
    isChain: boolean | null;
    responsibleNameEn: string;
    responsibleNameAr: string;
    building: string;
    floor: string;
    property: string;
    address: string;
    landmark: string;
    phone: string;
    taxCode: string;
    commercialCode: string;
    mobile: string;
    whatsApp: string;
    latitude: number | null;
    longitude: number | null;
    accuracy: number | null;
    inZone: boolean | null;
    operationStatusId: number | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

    operationRejectReasonId: number | null;


    documents: OperationRequestDetailDocumentListModel[];
    landmarks: OperationRequestDetailLandmarkListModel[];
    preferredTimes: OperationRequestDetailPreferredTimeListModel[];
}