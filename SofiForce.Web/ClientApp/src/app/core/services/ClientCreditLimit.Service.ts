import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ClientCreditLimitListModel } from '../Models/ListModels/ClientCreditLimitListModel';
import { JourneyDuplicateModel } from '../Models/DtoModels/JourneyDuplicateModel';
import { JourneyClearModel } from '../Models/DtoModels/JourneyClearModel';
import { ClientCreditLimitSearchModel } from '../Models/SearchModels/ClientCreditLimitSearchModel';
import { ClientCreditLimitModel } from '../Models/EntityModels/ClientCreditLimitModel';

@Injectable({
  providedIn: 'root'
})
export class ClientCreditLimitService {
  constructor(private _http: HttpClient) { }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<ClientCreditLimitListModel[]>>("ClientCreditLimit/filter", model).toPromise();
  }
  public Create = async (model) => {
    return this._http.post<ResponseModel<ClientCreditLimitListModel>>("ClientCreditLimit/Create", model).toPromise();
  }
  
  public Clear = async (model) => {
    return this._http.post<ResponseModel<ClientCreditLimitSearchModel>>("ClientCreditLimit/deleteAll", model).toPromise();
  }

  public Delete = async (model) => {
    return this._http.post<ResponseModel<ClientCreditLimitModel>>("ClientCreditLimit/Delete", model).toPromise();
  }
  public Download = async (model) => {
    return this._http.post("ClientCreditLimit/Download", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
  public  Template= async () => {
    return this._http.get("ClientCreditLimit/template",{
      reportProgress: true,
      responseType: 'blob'
    });
  }
  public  Missing= async () => {
    return this._http.get("ClientCreditLimit/missing",{
      reportProgress: true,
      responseType: 'blob'
    });
  }

  public getByRepresentative = async (Id) => {
    return this._http.get<ResponseModel<ClientCreditLimitListModel[]>>("ClientCreditLimit/getByRepresentative?Id="+Id).toPromise();
  }
}
