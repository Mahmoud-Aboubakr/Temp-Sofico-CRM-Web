import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';

import { RepresentativeListModel } from '../Models/ListModels/RepresentativeListModel';
import { SupervisorComissionModel } from '../Models/EntityModels/SupervisorComissionModel';
import { SupervisorComissionListModel } from '../Models/ListModels/SupervisorComissionListModel';

@Injectable({
  providedIn: 'root'
})
export class SupervisorComissionService {
  constructor(private _http: HttpClient) { }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<SupervisorComissionListModel[]>>("SupervisorComission/Filter", model).toPromise();
  }
  public Save = async (model) => {
    return this._http.post<ResponseModel<SupervisorComissionModel>>("SupervisorComission/Save", model).toPromise();
  }
  
  public getById = async (Id) => {
    return this._http.get<ResponseModel<SupervisorComissionModel>>("SupervisorComission/getById?Id="+Id).toPromise();
  }

  public getBySupervisor = async (Id) => {
    return this._http.get<ResponseModel<SupervisorComissionListModel[]>>("SupervisorComission/getBySupervisor?Id="+Id).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<SupervisorComissionModel>>("SupervisorComission/Delete", model).toPromise();
  }
  public Approve = async (model) => {
    return this._http.post<ResponseModel<SupervisorComissionModel>>("SupervisorComission/approve", model).toPromise();
  }


  public Export = (model)  => {
    return this._http.post("SupervisorComission/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
  
}
