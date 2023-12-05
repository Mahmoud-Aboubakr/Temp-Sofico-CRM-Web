import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../../Models/DtoModels/lookupModel';
import { PromotionMixGroupModel } from '../../Models/EntityModels/PromotionMixGroupModel';


@Injectable({
  providedIn: 'root'
})
export class PromotionMixGroupService {
  constructor(private _http: HttpClient) { }



  public Save = async (model) => {
    return this._http.post<ResponseModel<PromotionMixGroupModel>>("PromotionMixGroup/Save", model).toPromise();
  }

  public Delete = async (model) => {
    return this._http.post<ResponseModel<PromotionMixGroupModel>>("PromotionMixGroup/Delete", model).toPromise();
  }

  public GetByPromotion = async (Id) => {
    return this._http.get<ResponseModel<PromotionMixGroupModel[]>>("PromotionMixGroup/getByPromotion?Id="+Id).toPromise();
  }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<PromotionMixGroupModel[]>>("PromotionMixGroup/filter", model).toPromise();
  }

}
