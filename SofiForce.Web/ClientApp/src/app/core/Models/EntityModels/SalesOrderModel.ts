import { SalesOrderDetailListModel, SalesOrderPromotionOptionModel } from "../ListModels/SalesOrderDetailListModel";
import { SalesOrderErrorListModel } from "../ListModels/SalesOrderErrorListModel";
import { BranchModel } from "./branchModel";
import { ClientModel } from "./clientModel";
import { RepresentativeModel } from "./representativeModel";
import { SalesOrderTypeModel } from "./SalesOrderTypeModel";
import { StoreModel } from "./storeModel";

export class SalesOrderModel {
    salesId: number;
    salesCode: string;
    salesOrderTypeId: number | null;
    salesOrderType: SalesOrderTypeModel | null;

    clientId: number | null;
    clientCode: string | null;
    clientName: string | null;

    branchId: number | null;
    branchCode: string | null;
    branchName: string | null;

    agentId: number | null;
    representativeId: number | null;
    representativeCode:string | null;
    representativeName:string | null;

    storeId: number | null;
    storeCode:string |null;
    storeName:string |null;

    priorityTypeId: number | null;
    paymentTermId: number | null;
    salesDate: Date | null;
    salesTime: Date | null;
    salesOrderStatusId: number | null;
    salesOrderSourceId: number | null;
    latitude: number | null;
    longitude: number | null;
    itemTotal: number | null;
    itemDiscountTotal: number | null;
    taxTotal: number | null;
    cashDiscountTotal: number | null;
    customDiscountTotal: number | null;
    customDiscountValue:number;
    customDiscountTypeId:number;

    deliveryTotal: number | null;
    netTotal: number | null;
    notes: string;
    invoiceRetry: number | null;
    hasError: boolean | null;
    isInvoiced: boolean | null;
    invoiceCode: string;
    invoiceDate: Date | null;
    recId: number | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
    salesOrderDetails: SalesOrderDetailListModel[];
    promotionOptions:SalesOrderPromotionOptionModel[];
    errors: string[];
    warnings: string[];

    salesPerenId: number | null;


}