import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ClientServiceRequestListModel } from '../Models/ListModels/ClientServiceRequestListModel';
import { ClientServiceRequestModel } from '../Models/EntityModels/ClientServiceRequestModel';


@Injectable({
  providedIn: 'root'
})
export class ClientRequestService {
  constructor(private _http: HttpClient) { }
  
  public Filter = async (model) => {
    return this._http.post<ResponseModel<ClientServiceRequestListModel[]>>("ClientRequest/Filter", model).toPromise();
  }
  public Save = async (model) => {
    return this._http.post<ResponseModel<ClientServiceRequestModel>>("ClientRequest/Save", model).toPromise();
  }
  
  public getById = async (Id) => {
    return this._http.get<ResponseModel<ClientServiceRequestModel>>("ClientRequest/getById?Id="+Id).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<ClientServiceRequestModel>>("ClientRequest/Delete", model).toPromise();
  }
  public Export = (model)  => {
    return this._http.post("ClientRequest/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
  public Statistics = async (model) => {
    return this._http.post<ResponseModel<ClientServiceRequestModel>>("ClientRequest/Statistics", model).toPromise();
  }
}
