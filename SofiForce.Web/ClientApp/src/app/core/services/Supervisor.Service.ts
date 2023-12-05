import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { SupervisorListModel } from '../Models/ListModels/SupervisorListModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { SupervisorModel } from '../Models/EntityModels/supervisorModel';
import { RepresentativeListModel } from '../Models/ListModels/RepresentativeListModel';
import { RepresentativeModel } from '../Models/EntityModels/representativeModel';
import { AppUserModel } from '../Models/EntityModels/appUserModel';

@Injectable({
  providedIn: 'root'
})
export class SupervisorService {
  constructor(private _http: HttpClient) { }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<SupervisorListModel[]>>("Supervisor/Filter", model).toPromise();
  }

  public GetByUser = async (Id) => {
    return this._http.get<ResponseModel<SupervisorListModel[]>>("Supervisor/getByUser?Id="+Id).toPromise();
  }

  public Save = async (model) => {
    return this._http.post<ResponseModel<SupervisorModel>>("Supervisor/Save", model).toPromise();
  }
  
  public Status = async (model) => {
    return this._http.post<ResponseModel<SupervisorModel>>("Supervisor/Status", model).toPromise();
  }

  public CreateAccess = async (model) => {
    return this._http.post<ResponseModel<SupervisorModel>>("Supervisor/CreateAccess", model).toPromise();
  }
  
  public DeleteAccess = async (model) => {
    return this._http.post<ResponseModel<SupervisorModel>>("Supervisor/DeleteAccess", model).toPromise();
  }

  public getById = async (Id) => {
    return this._http.get<ResponseModel<SupervisorModel>>("Supervisor/getById?Id="+Id).toPromise();
  }

  public getReps = async (Id) => {
    return this._http.get<ResponseModel<RepresentativeListModel[]>>("Supervisor/getReps?Id="+Id).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<SupervisorModel>>("Supervisor/Delete", model).toPromise();
  }

  public addRep = async (model) => {
    return this._http.post<ResponseModel<RepresentativeModel>>("Supervisor/addRep", model).toPromise();
  }

  public deleteRep = async (model) => {
    return this._http.post<ResponseModel<RepresentativeModel>>("Supervisor/deleteRep", model).toPromise();
  }


  public Export = (model)  => {
    return this._http.post("Supervisor/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
  public Statistics = async (model) => {
    return this._http.post<ResponseModel<SupervisorModel>>("Supervisor/Statistics", model).toPromise();
  }
}
