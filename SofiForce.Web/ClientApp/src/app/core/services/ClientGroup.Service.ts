import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { ClientGroupModel } from '../Models/EntityModels/ClientGroupModel';
import { ClientGroupListModel } from '../Models/ListModels/ClientGroupListModel';

@Injectable({
  providedIn: 'root'
})
export class ClientGroupService {
  constructor(private _http: HttpClient) { }


  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("ClientGroup/GetAll").toPromise();
  }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<ClientGroupListModel[]>>("ClientGroup/Filter", model).toPromise();
  }
  public Save = async (model) => {
    return this._http.post<ResponseModel<ClientGroupModel>>("ClientGroup/Save", model).toPromise();
  }
  public getById = async (Id) => {
    return this._http.get<ResponseModel<ClientGroupModel>>("ClientGroup/getById?Id="+Id).toPromise();
  }
  
  public Delete = async (model) => {
    return this._http.post<ResponseModel<ClientGroupModel>>("ClientGroup/Delete", model).toPromise();
  }
  public Export = (model)  => {
    return this._http.post("ClientGroup/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
}
