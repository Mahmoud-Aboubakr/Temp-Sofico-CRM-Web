import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { RouteSetupListModel } from '../Models/ListModels/RouteSetupListModel';
import { RouteSetupModel } from '../Models/EntityModels/RouteSetupModel';

@Injectable({
  providedIn: 'root'
})
export class RouteSetupService {
  constructor(private _http: HttpClient) { }


  public Filter = async (model) => {
    return this._http.post<ResponseModel<RouteSetupListModel[]>>("RouteSetup/Filter", model).toPromise();
  }
  
  public Save = async (model) => {
    return this._http.post<ResponseModel<RouteSetupModel>>("RouteSetup/Save", model).toPromise();
  }
  public getById = async (Id) => {
    return this._http.get<ResponseModel<RouteSetupModel>>("RouteSetup/getById?Id="+Id).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<RouteSetupModel>>("RouteSetup/Delete", model).toPromise();
  }
  public Export = (model)  => {
    return this._http.post("RouteSetup/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }

}
