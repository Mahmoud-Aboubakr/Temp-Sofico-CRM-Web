import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ClientListModel } from '../Models/ListModels/ClientListModel';
import { ClientModel } from '../Models/EntityModels/clientModel';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  constructor(private _http: HttpClient) { }
  
  public Filter = async (model) => {
    return this._http.post<ResponseModel<ClientListModel[]>>("Client/Filter", model).toPromise();
  }
  public Save = async (model) => {
    return this._http.post<ResponseModel<ClientModel>>("Client/Save", model).toPromise();
  }
  
  public SaveBasic = async (model) => {
    return this._http.post<ResponseModel<ClientModel>>("Client/SaveBasic", model).toPromise();
  }
  public SaveContacts = async (model) => {
    return this._http.post<ResponseModel<ClientModel>>("Client/SaveContacts", model).toPromise();
  }
  public SaveAddress = async (model) => {
    return this._http.post<ResponseModel<ClientModel>>("Client/SaveAddress", model).toPromise();
  }
  public SaveLandMarks = async (model) => {
    return this._http.post<ResponseModel<ClientModel>>("Client/SaveLandMarks", model).toPromise();
  }
  public SavePrefferds = async (model) => {
    return this._http.post<ResponseModel<ClientModel>>("Client/SavePrefferds", model).toPromise();
  }

  public SaveDocuments = async (model) => {
    return this._http.post<ResponseModel<ClientModel>>("Client/SaveDocuments", model).toPromise();
  }

  public SaveRoutes = async (model) => {
    return this._http.post<ResponseModel<ClientModel>>("Client/SaveRoutes", model).toPromise();
  }
  

  public getById = async (Id) => {
    return this._http.get<ResponseModel<ClientModel>>("Client/getById?Id="+Id).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<ClientModel>>("Client/Delete", model).toPromise();
  }
  public Status = async (model) => {
    return this._http.post<ResponseModel<ClientModel>>("Client/Status", model).toPromise();
  }
  public Export = (model)  => {
    return this._http.post("Client/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
  public Statistics = async (model) => {
    return this._http.post<ResponseModel<ClientModel>>("Client/Statistics", model).toPromise();
  }
}
