import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../../Models/DtoModels/lookupModel';
import { PromtionCriteriaSalesManModel } from '../../Models/EntityModels/PromtionCriteriaSalesManModel';


@Injectable({
  providedIn: 'root'
})
export class PromtionCriteriaSalesManService {
  constructor(private _http: HttpClient) { }



  public Save = async (model) => {
    return this._http.post<ResponseModel<PromtionCriteriaSalesManModel>>("PromtionCriteriaSalesMan/Save", model).toPromise();
  }

  public Delete = async (model) => {
    return this._http.post<ResponseModel<PromtionCriteriaSalesManModel>>("PromtionCriteriaSalesMan/Delete", model).toPromise();
  }

  public GetByPromotion = async (Id) => {
    return this._http.get<ResponseModel<PromtionCriteriaSalesManModel[]>>("PromtionCriteriaSalesMan/getByPromotion?Id="+Id).toPromise();
  }

}
