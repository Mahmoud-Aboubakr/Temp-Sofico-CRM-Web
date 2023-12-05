import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../../Models/DtoModels/lookupModel';
import { PromotionOutcomeModel } from '../../Models/EntityModels/PromotionOutcomeModel';


@Injectable({
  providedIn: 'root'
})
export class PromotionOutcomeService {
  constructor(private _http: HttpClient) { }


  public Save = async (model) => {
    return this._http.post<ResponseModel<PromotionOutcomeModel>>("PromotionOutcome/Save", model).toPromise();
  }

  public Delete = async (model) => {
    return this._http.post<ResponseModel<PromotionOutcomeModel>>("PromotionOutcome/Delete", model).toPromise();
  }

  public GetByPromotion = async (Id) => {
    return this._http.get<ResponseModel<PromotionOutcomeModel[]>>("PromotionOutcome/getByPromotion?Id="+Id).toPromise();
  }


}
