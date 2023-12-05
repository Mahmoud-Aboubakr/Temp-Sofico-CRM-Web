import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { PromotionModel } from '../Models/EntityModels/PromotionModel';

@Injectable({
  providedIn: 'root'
})
export class ItemPromotionService {
  constructor(private _http: HttpClient) { }
  

  public GetByItem = async (ItemCode) => {
    return this._http.get<ResponseModel<PromotionModel>>(`ItemPromotion/getByItem?ItemCode=${ItemCode}`).toPromise();
  }

}
