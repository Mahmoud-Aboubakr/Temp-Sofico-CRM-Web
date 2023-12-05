import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { SalesOrderListModel } from '../Models/ListModels/SalesOrderListModel';
import { SalesOrderModel } from '../Models/EntityModels/salesOrderModel';
import { SalesOrderAddressModel } from '../Models/EntityModels/SalesOrderAddressModel';
import { ListNumberDto } from '../Models/DtoModels/ListNumberDto';

@Injectable({
  providedIn: 'root'
})
export class SalesOrderControlService {
  constructor(private _http: HttpClient) { }


  public Filter = async (model) => {
    return this._http.post<ResponseModel<SalesOrderListModel[]>>("SalesOrderControl/filter", model).toPromise();
  }
  
  public MarkTransfer = async (model) => {
    return this._http.post<ResponseModel<ListNumberDto>>("SalesOrderControl/markTransfer", model).toPromise();
  }
}
