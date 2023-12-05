import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { ClientTypeListModel } from '../Models/ListModels/ClientTypeListModel';
import { ClientTypeModel } from '../Models/EntityModels/ClientTypeModel';

@Injectable({
  providedIn: 'root'
})
export class ClientTypeService {
  constructor(private _http: HttpClient) { }


  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("ClientType/GetAll").toPromise();
  }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<ClientTypeListModel[]>>("ClientType/Filter", model).toPromise();
  }

  public Save = async (model) => {
    return this._http.post<ResponseModel<ClientTypeModel>>("ClientType/Save", model).toPromise();
  }
  public getById = async (Id) => {
    return this._http.get<ResponseModel<ClientTypeModel>>("ClientType/getById?Id="+Id).toPromise();
  }
  
  public Delete = async (model) => {
    return this._http.post<ResponseModel<ClientTypeModel>>("ClientType/Delete", model).toPromise();
  }
  public Export = (model)  => {
    return this._http.post("ClientGroup/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
}
