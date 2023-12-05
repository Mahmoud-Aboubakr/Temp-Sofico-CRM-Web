import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';

@Injectable({
  providedIn: 'root'
})
export class ComplainTypeDetailService {
  constructor(private _http: HttpClient) { }


  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("ComplainTypeDetail/GetAll").toPromise();
  }
  public GetByTypeId = async (Id) => {
    return this._http.get<ResponseModel<LookupModel[]>>("ComplainTypeDetail/GetByTypeId?Id="+Id).toPromise();
  }

}
