import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { ClientClassificationModel } from '../Models/EntityModels/ClientClassificationModel';
import { ClientClassificationListModel } from '../Models/ListModels/ClientClassificationListModel';

@Injectable({
  providedIn: 'root'
})
export class ClientClassificationService {
  constructor(private _http: HttpClient) { }


  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("ClientClassification/GetAll").toPromise();
  }


  public Filter = async (model) => {
    return this._http.post<ResponseModel<ClientClassificationListModel[]>>("ClientClassification/Filter", model).toPromise();
  }
  public Save = async (model) => {
    return this._http.post<ResponseModel<ClientClassificationModel>>("ClientClassification/Save", model).toPromise();
  }
  public getById = async (Id) => {
    return this._http.get<ResponseModel<ClientClassificationModel>>("ClientClassification/getById?Id="+Id).toPromise();
  }
  
  public Delete = async (model) => {
    return this._http.post<ResponseModel<ClientClassificationModel>>("ClientClassification/Delete", model).toPromise();
  }
  public Export = (model)  => {
    return this._http.post("ClientClassification/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
}
