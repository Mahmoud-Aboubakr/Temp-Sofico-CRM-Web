import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ClientRouteListModel } from '../Models/ListModels/ClientRouteListModel';
import { ClientRouteModel } from '../Models/EntityModels/ClientRouteModel';
import { FileModel } from '../Models/DtoModels/FileModel';

@Injectable({
  providedIn: 'root'
})
export class ClientRouteService {
  constructor(private _http: HttpClient) { }


  public Filter = async (model) => {
    return this._http.post<ResponseModel<ClientRouteListModel[]>>("ClientRoute/Filter", model).toPromise();
  }
  public Upload = async (model) => {
    return this._http.post<ResponseModel<FileModel>>("ClientRoute/Upload", model).toPromise();
  }

  

  public GetById = async (Id) => {
    return this._http.get<ResponseModel<ClientRouteListModel[]>>("ClientRoute/getById?Id="+Id).toPromise();
  }


  public Save = async (model) => {
    return this._http.post<ResponseModel<ClientRouteModel>>("ClientRoute/Save", model).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<ClientRouteModel>>("ClientRoute/Delete", model).toPromise();
  }


  public Export = async (model) => {
    return this._http.post("ClientRoute/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }

}
