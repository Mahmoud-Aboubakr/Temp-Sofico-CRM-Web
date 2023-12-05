import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { ClientGroupSubModel } from '../Models/EntityModels/clientGroupSubModel';
import { ClientGroupSubListModel } from '../Models/ListModels/ClientGroupSubListModel';

@Injectable({
  providedIn: 'root'
})
export class ClientGroupSubService {
  constructor(private _http: HttpClient) { }



  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("ClientGroupSub/GetAll").toPromise();
  }
  public GetByClientGroup = async (Id) => {
    return this._http.get<ResponseModel<LookupModel[]>>("ClientGroupSub/GetByClientGroup?Id="+Id).toPromise();
  }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<ClientGroupSubListModel[]>>("ClientGroupSub/Filter", model).toPromise();
  }
  public Save = async (model) => {
    return this._http.post<ResponseModel<ClientGroupSubModel>>("ClientGroupSub/Save", model).toPromise();
  }
  public getById = async (Id) => {
    return this._http.get<ResponseModel<ClientGroupSubModel>>("ClientGroupSub/getById?Id="+Id).toPromise();
  }
  
  public Delete = async (model) => {
    return this._http.post<ResponseModel<ClientGroupSubModel>>("ClientGroupSub/Delete", model).toPromise();
  }
  public Export = (model)  => {
    return this._http.post("ClientGroup/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }

}
