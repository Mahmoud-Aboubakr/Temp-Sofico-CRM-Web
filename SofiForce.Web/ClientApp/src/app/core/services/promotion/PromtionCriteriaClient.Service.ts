import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../../Models/DtoModels/lookupModel';
import { PromtionCriteriaClientModel } from '../../Models/EntityModels/PromtionCriteriaClientModel';


@Injectable({
  providedIn: 'root'
})
export class PromtionCriteriaClientService {
  constructor(private _http: HttpClient) { }



  public Save = async (model) => {
    return this._http.post<ResponseModel<PromtionCriteriaClientModel>>("PromtionCriteriaClient/Save", model).toPromise();
  }

  public Delete = async (model) => {
    return this._http.post<ResponseModel<PromtionCriteriaClientModel>>("PromtionCriteriaClient/Delete", model).toPromise();
  }

  public GetByPromotion = async (Id) => {
    return this._http.get<ResponseModel<PromtionCriteriaClientModel[]>>("PromtionCriteriaClient/getByPromotion?Id="+Id).toPromise();
  }

}
