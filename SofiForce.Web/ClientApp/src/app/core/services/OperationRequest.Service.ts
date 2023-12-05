import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { OperationRequestListModel } from '../Models/ListModels/OperationRequestListModel';
import { OperationRequestModel } from '../Models/EntityModels/OperationRequestModel';
import { GeoPoint } from '../Models/DtoModels/GeoPoint';


@Injectable({
  providedIn: 'root'
})
export class OperationRequestService {
  constructor(private _http: HttpClient) { }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<OperationRequestListModel[]>>("OperationRequest/Filter", model).toPromise();
  }
  
  public Save = async (model) => {
    return this._http.post<ResponseModel<OperationRequestModel>>("OperationRequest/Save", model).toPromise();
  }
  public getById = async (Id) => {
    return this._http.get<ResponseModel<OperationRequestModel>>("OperationRequest/getById?Id="+Id).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<OperationRequestModel>>("OperationRequest/Delete", model).toPromise();
  }

  public Export = (model)  => {
    return this._http.post("OperationRequest/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }

  public parse = async (file)  => {

    let formData:FormData = new FormData();
    formData.append('uploadFile', file, file.name);
    let _headers = new HttpHeaders();
    _headers.append('Content-Type', 'multipart/form-data');
    _headers.append('Accept', 'application/json');

    return this._http.post<ResponseModel<GeoPoint[]>>("OperationRequest/parse", formData, { headers: _headers }).toPromise()
  }

  public parseClients = async (file)  => {

    let formData:FormData = new FormData();
    formData.append('uploadFile', file, file.name);
    let _headers = new HttpHeaders();
    _headers.append('Content-Type', 'multipart/form-data');
    _headers.append('Accept', 'application/json');

    return this._http.post<ResponseModel<GeoPoint[]>>("OperationRequest/parseClients", formData, { headers: _headers }).toPromise()
  }
  
}
