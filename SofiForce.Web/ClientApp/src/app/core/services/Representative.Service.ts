import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { RepresentativeListModel } from '../Models/ListModels/RepresentativeListModel';
// import { RepresentativeModel } from '../Models/EntityModels/representativeModel';
import { RepresentativeModel } from '../Models/EntityModels/RepresentativeModel';

@Injectable({
  providedIn: 'root'
})
export class RepresentativeService {
  constructor(private _http: HttpClient) { }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<RepresentativeListModel[]>>("Representative/Filter", model).toPromise();
  }
  
  public CreateAccess = async (model) => {
    return this._http.post<ResponseModel<RepresentativeModel>>("Representative/CreateAccess", model).toPromise();
  }

    public DeleteAccess = async (model) => {
    return this._http.post<ResponseModel<RepresentativeModel>>("Representative/DeleteAccess", model).toPromise();
  }

  public GetByUser = async (Id) => {
    return this._http.get<ResponseModel<RepresentativeListModel[]>>("Representative/getByUser?Id="+Id).toPromise();
  }
  

  public Status = async (model) => {
    return this._http.post<ResponseModel<RepresentativeModel>>("Representative/Status", model).toPromise();
  }

  public Save = async (model) => {
    return this._http.post<ResponseModel<RepresentativeModel>>("Representative/Save", model).toPromise();
  }
  public getById = async (Id) => {
    return this._http.get<ResponseModel<RepresentativeModel>>("Representative/getById?Id="+Id).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<RepresentativeModel>>("Representative/Delete", model).toPromise();
  }
  public Export = (model)  => {
    return this._http.post("Representative/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
  public Statistics = async (model) => {
    return this._http.post<ResponseModel<RepresentativeModel>>("Representative/Statistics", model).toPromise();
  }
}
