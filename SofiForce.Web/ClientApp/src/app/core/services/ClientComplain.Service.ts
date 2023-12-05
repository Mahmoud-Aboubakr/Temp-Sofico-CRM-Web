import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ClientComplainListModel } from '../Models/ListModels/ClientComplainListModel';
import { ClientComplainModel } from '../Models/EntityModels/ClientComplainModel';

@Injectable({
  providedIn: 'root'
})
export class ClientComplainService {
  constructor(private _http: HttpClient) { }
  
  public Filter = async (model) => {
    return this._http.post<ResponseModel<ClientComplainListModel[]>>("ClientComplain/Filter", model).toPromise();
  }
  public Save = async (model) => {
    return this._http.post<ResponseModel<ClientComplainModel>>("ClientComplain/Save", model).toPromise();
  }
  
  public getById = async (Id) => {
    return this._http.get<ResponseModel<ClientComplainModel>>("ClientComplain/getById?Id="+Id).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<ClientComplainModel>>("ClientComplain/Delete", model).toPromise();
  }
  public Export = (model)  => {
    return this._http.post("ClientComplain/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
  public Statistics = async (model) => {
    return this._http.post<ResponseModel<ClientComplainModel>>("ClientComplain/Statistics", model).toPromise();
  }
}
