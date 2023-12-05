import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../../Models/ResponseModels/ResponseModel';

import { PromotionItemBundleModel } from '../../Models/EntityModels/PromotionItemBundleModel';
import { PromotionItemBundleListModel } from '../../Models/ListModels/PromotionItemBundleListModel';


@Injectable({
  providedIn: 'root'
})
export class PromotionItemBundleService {
  constructor(private _http: HttpClient) { }


  public Save = async (model) => {
    return this._http.post<ResponseModel<PromotionItemBundleModel>>("PromotionItemBundle/Save", model).toPromise();
  }

  public Delete = async (model) => {
    return this._http.post<ResponseModel<PromotionItemBundleModel>>("PromotionItemBundle/Delete", model).toPromise();
  }

  public GetByPromotion = async (Id) => {
    return this._http.get<ResponseModel<PromotionItemBundleListModel[]>>("PromotionItemBundle/getByPromotion?Id="+Id).toPromise();
  }


}
