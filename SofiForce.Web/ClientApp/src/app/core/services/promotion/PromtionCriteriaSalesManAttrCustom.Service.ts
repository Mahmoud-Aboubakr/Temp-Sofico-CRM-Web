import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../../Models/ResponseModels/ResponseModel';
import { PromtionCriteriaSalesManAttrCustomModel } from '../../Models/EntityModels/PromtionCriteriaSalesManAttrCustomModel';


@Injectable({
  providedIn: 'root'
})
export class PromtionCriteriaSalesManAttrCustomService {
  constructor(private _http: HttpClient) { }



  public Save = async (model) => {
    return this._http.post<ResponseModel<PromtionCriteriaSalesManAttrCustomModel>>("PromtionCriteriaSalesManAttrCustom/Save", model).toPromise();
  }

  public getByAttribute = async (Id) => {
    return this._http.get<ResponseModel<PromtionCriteriaSalesManAttrCustomModel[]>>("PromtionCriteriaSalesManAttrCustom/getByAttribute?Id="+Id).toPromise();
  }

  public Delete = async (model) => {
    return this._http.post<ResponseModel<PromtionCriteriaSalesManAttrCustomModel>>("PromtionCriteriaSalesManAttrCustom/Delete", model).toPromise();
  }

}
