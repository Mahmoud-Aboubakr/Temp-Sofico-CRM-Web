import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { SalesOrderListModel } from '../Models/ListModels/SalesOrderListModel';
import { SalesOrderModel } from '../Models/EntityModels/salesOrderModel';

@Injectable({
  providedIn: 'root'
})
export class ReturnOrderService {
  constructor(private _http: HttpClient) { }


  public Filter = async (model) => {
    return this._http.post<ResponseModel<SalesOrderListModel[]>>("ReturnOrder/filter", model).toPromise();
  }
  

  public Save = async (model) => {
    return this._http.post<ResponseModel<SalesOrderModel>>("ReturnOrder/Save", model).toPromise();
  }


  public Delete = async (model) => {
    return this._http.post<ResponseModel<SalesOrderModel>>("ReturnOrder/delete", model).toPromise();
  }

  public Approve = async (model) => {
    return this._http.post<ResponseModel<SalesOrderModel>>("ReturnOrder/approve", model).toPromise();
  }
  public Promotion = async (model) => {
    return this._http.post<ResponseModel<SalesOrderModel>>("ReturnOrder/promotion", model).toPromise();
  }

  public Transfer = async (model) => {
    return this._http.post<ResponseModel<SalesOrderModel>>("ReturnOrder/transfer", model).toPromise();
  }

  public Validate = async (model) => {
    return this._http.post<ResponseModel<SalesOrderModel>>("ReturnOrder/validate", model).toPromise();
  }

  public getByCode = async (InvoiceCode) => {
    return this._http.get<ResponseModel<SalesOrderModel>>("ReturnOrder/getByCode?InvoiceCode="+InvoiceCode).toPromise();
  }
  public getById = async (Id) => {
    return this._http.get<ResponseModel<SalesOrderModel>>("ReturnOrder/getById?Id="+Id).toPromise();
  }
  
}
