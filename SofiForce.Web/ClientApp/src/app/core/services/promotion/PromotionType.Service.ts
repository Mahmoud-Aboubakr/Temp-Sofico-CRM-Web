import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../../Models/DtoModels/lookupModel';
import { PromotionTypeModel } from '../../Models/EntityModels/PromotionTypeModel';


@Injectable({
  providedIn: 'root'
})
export class PromotionTypeService {
  constructor(private _http: HttpClient) { }



  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("PromotionType/GetAll").toPromise();
  }
  public GetById = async (Id) => {
    return this._http.get<ResponseModel<PromotionTypeModel>>("PromotionType/GetById?Id="+Id).toPromise();
  }

  public Save = async (Model) => {
    return this._http.post<ResponseModel<PromotionTypeModel>>("PromotionType/Save",Model).toPromise();
  }

  public Delete = async (Model) => {
    return this._http.post<ResponseModel<PromotionTypeModel>>("PromotionType/Delete",Model).toPromise();
  }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<PromotionTypeModel[]>>("PromotionType/filter", model).toPromise();
  }

}
