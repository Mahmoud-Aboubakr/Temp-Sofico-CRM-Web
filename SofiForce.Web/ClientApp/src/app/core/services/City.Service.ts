import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { CityListModel } from '../Models/ListModels/CityListModel';

@Injectable({
  providedIn: 'root'
})
export class CityService {
  constructor(private _http: HttpClient) { }


  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("City/GetAll").toPromise();
  }

  public GetByGovernerate = async (Id) => {
    return this._http.get<ResponseModel<LookupModel[]>>("City/GetByGovernerate?Id="+Id).toPromise();
  }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<CityListModel[]>>("City/Filter", model).toPromise();
  }

}
