import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { RepresentativeJourneyListModel } from '../Models/ListModels/RepresentativeJourneyListModel';
import { RepresentativeJourneyModel } from '../Models/EntityModels/RepresentativeJourneyModel';
import { JourneyDuplicateModel } from '../Models/DtoModels/JourneyDuplicateModel';
import { JourneyClearModel } from '../Models/DtoModels/JourneyClearModel';
import { RepresentativeJourneyKBIModel } from '../Models/StatisticalModels/RepresentativeJourneyKBIModel';

@Injectable({
  providedIn: 'root'
})
export class RepresentativeJourneyService {
  constructor(private _http: HttpClient) { }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<RepresentativeJourneyListModel[]>>("RepresentativeJourney/filter", model).toPromise();
  }
  public Create = async (model) => {
    return this._http.post<ResponseModel<RepresentativeJourneyListModel>>("RepresentativeJourney/Create", model).toPromise();
  }

  public getById = async (Id) => {
    return this._http.get<ResponseModel<RepresentativeJourneyModel>>("RepresentativeJourney/getById?Id="+Id).toPromise();
  }


  public Clear = async (model) => {
    return this._http.post<ResponseModel<JourneyClearModel>>("RepresentativeJourney/Clear", model).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<RepresentativeJourneyModel>>("RepresentativeJourney/Delete", model).toPromise();
  }
  public Add = async (model) => {
    return this._http.post<ResponseModel<RepresentativeJourneyModel>>("RepresentativeJourney/Add", model).toPromise();
  }
  public Duplicate = async (model) => {
    return this._http.post<ResponseModel<JourneyDuplicateModel>>("RepresentativeJourney/Duplicate", model).toPromise();
  }
  public Save = async (model) => {
    return this._http.post<ResponseModel<RepresentativeJourneyModel>>("RepresentativeJourney/Save", model).toPromise();
  }
  public Download = async (model) => {
    return this._http.post("RepresentativeJourney/Download", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
  public  Template= async () => {
    return this._http.get("RepresentativeJourney/template",{
      reportProgress: true,
      responseType: 'blob'
    });
  }
  public  Missing= async () => {
    return this._http.get("RepresentativeJourney/missing",{
      reportProgress: true,
      responseType: 'blob'
    });
  }

  public getByRepresentative = async (Id) => {
    return this._http.get<ResponseModel<RepresentativeJourneyListModel[]>>("RepresentativeJourney/getByRepresentative?Id="+Id).toPromise();
  }
}
