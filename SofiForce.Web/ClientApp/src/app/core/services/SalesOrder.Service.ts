import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { SalesOrderListModel } from '../Models/ListModels/SalesOrderListModel';
import { SalesOrderModel } from '../Models/EntityModels/salesOrderModel';
import { SalesOrderAddressModel } from '../Models/EntityModels/SalesOrderAddressModel';

@Injectable({
  providedIn: 'root'
})
export class SalesOrderService {
  constructor(private _http: HttpClient) { }


  public Filter = async (model) => {
    return this._http.post<ResponseModel<SalesOrderListModel[]>>("SalesOrder/filter", model).toPromise();
  }
  
  public SaveHeader = async (model) => {
    return this._http.post<ResponseModel<SalesOrderModel>>("SalesOrder/SaveHeader", model).toPromise();
  }
  public SaveDetails = async (model) => {
    return this._http.post<ResponseModel<SalesOrderModel>>("SalesOrder/saveItems", model).toPromise();
  }
  public saveAddress = async (model) => {
    return this._http.post<ResponseModel<SalesOrderAddressModel>>("SalesOrder/saveAddress", model).toPromise();
  }

  public Promotion = async (model) => {
    return this._http.post<ResponseModel<SalesOrderModel>>("SalesOrder/Promotion", model).toPromise();
  }

  public Delete = async (model) => {
    return this._http.post<ResponseModel<SalesOrderModel>>("SalesOrder/delete", model).toPromise();
  }
  public ClearCash = async (model) => {
    return this._http.post<ResponseModel<SalesOrderModel>>("SalesOrder/clear-cash", model).toPromise();
  }

  public Copy = async (model) => {
    return this._http.post<ResponseModel<SalesOrderModel>>("SalesOrder/copy", model).toPromise();
  }


  public Approve = async (model) => {
    return this._http.post<ResponseModel<SalesOrderModel>>("SalesOrder/approve", model).toPromise();
  }

  public Open = async (model) => {
    return this._http.post<ResponseModel<SalesOrderModel>>("SalesOrder/Open", model).toPromise();
  }
  public OpenAll = async (model) => {
    return this._http.post<ResponseModel<SalesOrderModel>>("SalesOrder/OpenAll", model).toPromise();
  }
  

  public Transfer = async (model) => {
    return this._http.post<ResponseModel<SalesOrderModel>>("SalesOrder/transfer", model).toPromise();
  }
  public getById = async (Id) => {
    return this._http.get<ResponseModel<SalesOrderModel>>("SalesOrder/getById?Id="+Id).toPromise();
  }
  public getAddress = async (Id) => {
    return this._http.get<ResponseModel<SalesOrderAddressModel>>("SalesOrder/getAddress?Id="+Id).toPromise();
  }
}
