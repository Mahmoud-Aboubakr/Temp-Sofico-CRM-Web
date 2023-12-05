import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ClientListModel } from '../Models/ListModels/ClientListModel';
import { ClientModel } from '../Models/EntityModels/clientModel';
import { ClientSurveyListModel } from '../Models/ListModels/ClientSurveyListModel';
import { ClientSurveyModel } from '../Models/EntityModels/ClientSurveyModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { SurveyModel } from '../Models/EntityModels/SurveyModel';

@Injectable({
  providedIn: 'root'
})
export class SurveyService {
  constructor(private _http: HttpClient) { }
  

  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("Survey/GetAll").toPromise();
  }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<SurveyModel[]>>("Survey/Filter", model).toPromise();
  }
  public Save = async (model) => {
    return this._http.post<ResponseModel<SurveyModel>>("Survey/Save", model).toPromise();
  }
  
  public getById = async (Id) => {
    return this._http.get<ResponseModel<SurveyModel>>("Survey/getById?Id="+Id).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<SurveyModel>>("Survey/Delete", model).toPromise();
  }
  public Export = (model)  => {
    return this._http.post("Survey/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
}
