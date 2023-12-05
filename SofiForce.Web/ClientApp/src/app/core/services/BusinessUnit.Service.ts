import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { BusinessUnitListModel } from '../Models/ListModels/BusinessUnitListModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { BusinessUnitModel } from '../Models/EntityModels/BusinessUnitModel';

@Injectable({
  providedIn: 'root'
})
export class BusinessUnitService {
  constructor(private _http: HttpClient) { }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<BusinessUnitListModel[]>>("BusinessUnit/Filter", model).toPromise();
  }
  public Save = async (model) => {
    return this._http.post<ResponseModel<BusinessUnitModel>>("BusinessUnit/Save", model).toPromise();

  }

  public getAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("BusinessUnit/getAll").toPromise();
  }

  public getById = async (Id) => {
    return this._http.get<ResponseModel<BusinessUnitModel>>("BusinessUnit/getById?Id="+Id).toPromise();
  }
  public getByBranch = async (Id) => {
    return this._http.get<ResponseModel<LookupModel[]>>("BusinessUnit/getByBranch?Id="+Id).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<BusinessUnitModel>>("BusinessUnit/Delete", model).toPromise();
  }
  public Export = (model)  => {
    return this._http.post("BusinessUnit/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
}
