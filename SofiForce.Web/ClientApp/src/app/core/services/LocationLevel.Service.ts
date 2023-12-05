import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { LocationLevelListModel } from '../Models/ListModels/LocationLevelListModel';

@Injectable({
  providedIn: 'root'
})
export class LocationLevelService {
  constructor(private _http: HttpClient) { }


  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("LocationLevel/GetAll").toPromise();
  }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<LocationLevelListModel[]>>("LocationLevel/Filter", model).toPromise();
  }

}
