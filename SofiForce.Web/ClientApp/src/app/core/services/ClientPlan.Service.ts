import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ClientPlanListModel } from '../Models/ListModels/ClientPlanListModel';
import { ClientPlanModel } from '../Models/EntityModels/ClientPlanModel';
import { ClientPlanClearModel } from '../Models/DtoModels/ClientPlanClearModel';
import { ClientPlanDuplicateModel } from '../Models/DtoModels/ClientPlanDuplicateModel';

@Injectable({
  providedIn: 'root'
})
export class ClientPlanService {
  constructor(private _http: HttpClient) { }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<ClientPlanListModel[]>>("ClientPlan/filter", model).toPromise();
  }
  public Create = async (model) => {
    return this._http.post<ResponseModel<ClientPlanModel>>("ClientPlan/Create", model).toPromise();
  }

  public getById = async (Id) => {
    return this._http.get<ResponseModel<ClientPlanModel>>("ClientPlan/getById?Id="+Id).toPromise();
  }
  public getStc = async () => {
    return this._http.get<ResponseModel<ClientPlanModel>>("ClientPlan/stc").toPromise();
  }

  public Clear = async (model) => {
    return this._http.post<ResponseModel<ClientPlanClearModel>>("ClientPlan/Clear", model).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<ClientPlanModel>>("ClientPlan/Delete", model).toPromise();
  }
  public Duplicate = async (model) => {
    return this._http.post<ResponseModel<ClientPlanDuplicateModel>>("ClientPlan/Duplicate", model).toPromise();
  }
  public Save = async (model) => {
    return this._http.post<ResponseModel<ClientPlanModel>>("ClientPlan/Save", model).toPromise();
  }
  public Download = async (model) => {
    return this._http.post("ClientPlan/Download", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
  public  Template= async () => {
    return this._http.get("ClientPlan/template",{
      reportProgress: true,
      responseType: 'blob'
    });
  }
}
