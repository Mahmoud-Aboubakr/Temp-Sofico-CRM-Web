import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ClientListModel } from '../Models/ListModels/ClientListModel';
import { ClientModel } from '../Models/EntityModels/clientModel';
import { ClientSurveyListModel } from '../Models/ListModels/ClientSurveyListModel';
import { ClientSurveyModel } from '../Models/EntityModels/ClientSurveyModel';

@Injectable({
  providedIn: 'root'
})
export class ClientSurveyService {
  constructor(private _http: HttpClient) { }
  
  public Filter = async (model) => {
    return this._http.post<ResponseModel<ClientSurveyListModel[]>>("ClientSurvey/Filter", model).toPromise();
  }
  public Save = async (model) => {
    return this._http.post<ResponseModel<ClientSurveyModel>>("ClientSurvey/Save", model).toPromise();
  }
  
  public getById = async (ClientServeyId) => {
    return this._http.get<ResponseModel<ClientSurveyModel>>("ClientSurvey/getById?Id="+ClientServeyId).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<ClientSurveyModel>>("ClientSurvey/Delete", model).toPromise();
  }
  public Export = (model)  => {
    return this._http.post("ClientSurvey/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
}
