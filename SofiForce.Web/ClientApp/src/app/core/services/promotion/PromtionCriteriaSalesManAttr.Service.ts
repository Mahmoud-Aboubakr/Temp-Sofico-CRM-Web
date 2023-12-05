import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../../Models/DtoModels/lookupModel';
import { PromtionCriteriaSalesManAttrModel } from '../../Models/EntityModels/PromtionCriteriaSalesManAttrModel';


@Injectable({
  providedIn: 'root'
})
export class PromtionCriteriaSalesManAttrService {
  constructor(private _http: HttpClient) { }


  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("PromtionCriteriaSalesManAttr/GetAll").toPromise();
  }

  public GetById = async (Id) => {
    return this._http.get<ResponseModel<PromtionCriteriaSalesManAttrModel>>("PromtionCriteriaSalesManAttr/GetById?Id="+Id).toPromise();
  }

  public Save = async (Model) => {
    return this._http.post<ResponseModel<PromtionCriteriaSalesManAttrModel>>("PromtionCriteriaSalesManAttr/Save",Model).toPromise();
  }
  public Delete = async (Model) => {
    return this._http.post<ResponseModel<PromtionCriteriaSalesManAttrModel>>("PromtionCriteriaSalesManAttr/Delete",Model).toPromise();
  }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<PromtionCriteriaSalesManAttrModel[]>>("PromtionCriteriaSalesManAttr/filter", model).toPromise();
  }
}
