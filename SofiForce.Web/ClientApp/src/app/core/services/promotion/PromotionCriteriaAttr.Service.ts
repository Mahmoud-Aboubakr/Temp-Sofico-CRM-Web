import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../../Models/DtoModels/lookupModel';
import { PromotionCriteriaAttrModel } from '../../Models/EntityModels/PromotionCriteriaAttrModel';


@Injectable({
  providedIn: 'root'
})
export class PromotionCriteriaAttrService {
  constructor(private _http: HttpClient) { }


  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("PromotionCriteriaAttr/GetAll").toPromise();
  }

  public GetById = async (Id) => {
    return this._http.get<ResponseModel<PromotionCriteriaAttrModel>>("PromotionCriteriaAttr/GetById?Id="+Id).toPromise();
  }

  public Save = async (Model) => {
    return this._http.post<ResponseModel<PromotionCriteriaAttrModel>>("PromotionCriteriaAttr/Save",Model).toPromise();
  }

  public Delete = async (Model) => {
    return this._http.post<ResponseModel<PromotionCriteriaAttrModel>>("PromotionCriteriaAttr/Delete",Model).toPromise();
  }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<PromotionCriteriaAttrModel[]>>("PromotionCriteriaAttr/filter", model).toPromise();
  }

}
