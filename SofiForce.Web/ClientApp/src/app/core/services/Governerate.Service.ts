import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { GovernerateListModel } from '../Models/ListModels/GovernerateListModel';

@Injectable({
  providedIn: 'root'
})
export class GovernerateService {
  constructor(private _http: HttpClient) { }


  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("Governerate/GetAll").toPromise();
  }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<GovernerateListModel[]>>("Governerate/Filter", model).toPromise();
  }

}
