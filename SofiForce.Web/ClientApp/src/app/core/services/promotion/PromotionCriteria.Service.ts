import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../../Models/DtoModels/lookupModel';
import { PromotionCriteriaModel } from '../../Models/EntityModels/PromotionCriteriaModel';


@Injectable({
  providedIn: 'root'
})
export class PromotionCriteriaService {
  constructor(private _http: HttpClient) { }


  public Save = async (model) => {
    return this._http.post<ResponseModel<PromotionCriteriaModel>>("PromotionCriteria/Save", model).toPromise();
  }

  public Delete = async (model) => {
    return this._http.post<ResponseModel<PromotionCriteriaModel>>("PromotionCriteria/Delete", model).toPromise();
  }

  public GetByPromotion = async (Id) => {
    return this._http.get<ResponseModel<PromotionCriteriaModel[]>>("PromotionCriteria/getByPromotion?Id="+Id).toPromise();
  }


}
