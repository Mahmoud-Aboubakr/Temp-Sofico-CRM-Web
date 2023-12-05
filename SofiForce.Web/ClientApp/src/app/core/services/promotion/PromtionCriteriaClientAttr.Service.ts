import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../../Models/DtoModels/lookupModel';
import { PromtionCriteriaClientAttrModel } from '../../Models/EntityModels/PromtionCriteriaClientAttrModel';


@Injectable({
  providedIn: 'root'
})
export class PromtionCriteriaClientAttrService {
  constructor(private _http: HttpClient) { }


  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("PromtionCriteriaClientAttr/GetAll").toPromise();
  }

  public GetById = async (Id) => {
    return this._http.get<ResponseModel<PromtionCriteriaClientAttrModel>>("PromtionCriteriaClientAttr/GetById?Id="+Id).toPromise();
  }

  public Save = async (Model) => {
    return this._http.post<ResponseModel<PromtionCriteriaClientAttrModel>>("PromtionCriteriaClientAttr/Save",Model).toPromise();
  }
  public Delete = async (Model) => {
    return this._http.post<ResponseModel<PromtionCriteriaClientAttrModel>>("PromtionCriteriaClientAttr/Delete",Model).toPromise();
  }


  public Filter = async (model) => {
    return this._http.post<ResponseModel<PromtionCriteriaClientAttrModel[]>>("PromtionCriteriaClientAttr/filter", model).toPromise();
  }
}
