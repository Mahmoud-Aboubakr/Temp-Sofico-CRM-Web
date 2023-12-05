import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ClientActivityModel } from '../Models/EntityModels/ClientActivityModel';
import { ClientActivityListModel } from '../Models/ListModels/ClientActivityListModel';

@Injectable({
  providedIn: 'root'
})
export class ClientActivityService {
  constructor(private _http: HttpClient) { }
  
  public Filter = async (model) => {
    return this._http.post<ResponseModel<ClientActivityListModel[]>>("ClientActivity/Filter", model).toPromise();
  }
  public Save = async (model) => {
    return this._http.post<ResponseModel<ClientActivityModel>>("ClientActivity/Save", model).toPromise();
  }
  
  public getById = async (Id) => {
    return this._http.get<ResponseModel<ClientActivityModel>>("ClientActivity/getById?Id="+Id).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<ClientActivityModel>>("ClientActivity/Delete", model).toPromise();
  }
  public Export = (model)  => {
    return this._http.post("ClientActivity/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }

}
