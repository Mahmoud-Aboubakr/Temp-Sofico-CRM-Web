import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { SalesOrderLinePromotionListModel } from '../Models/ListModels/SalesOrderLinePromotionListModel';

@Injectable({
  providedIn: 'root'
})
export class SalesOrderLinePromotionService {
  constructor(private _http: HttpClient) { }
  
  public Filter = async (model) => {
    return this._http.post<ResponseModel<SalesOrderLinePromotionListModel[]>>("SalesOrderLinePromotion/filter", model).toPromise();
  }
  public Download = (model)  => {
    return this._http.post("SalesOrderLinePromotion/download", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }

}
