import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../../Models/DtoModels/lookupModel';


@Injectable({
  providedIn: 'root'
})
export class PromotionRepeatTypeService {
  constructor(private _http: HttpClient) { }


  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("PromotionRepeatType/GetAll").toPromise();
  }


}
