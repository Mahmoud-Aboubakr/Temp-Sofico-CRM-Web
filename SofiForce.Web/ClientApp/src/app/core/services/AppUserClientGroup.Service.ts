import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { AppUserClientGroupModel } from '../Models/EntityModels/AppUserClientGroupModel';
import { AppUserClientGroupListModel } from '../Models/ListModels/AppUserClientGroupListModel';

@Injectable({
  providedIn: 'root'
})
export class AppUserClientGroupService {
  constructor(private _http: HttpClient) { }


  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("AppUserClientGroup/GetAll").toPromise();
  }

  public Save = async (model) => {
    return this._http.post<ResponseModel<AppUserClientGroupModel>>("AppUserClientGroup/Save",model).toPromise();
  }

  public Delete = async (model) => {
    return this._http.post<ResponseModel<AppUserClientGroupModel>>("AppUserClientGroup/Delete",model).toPromise();
  }
  public GetByUser = async (Id) => {
    return this._http.get<ResponseModel<AppUserClientGroupListModel[]>>("AppUserClientGroup/getByUser?Id="+Id).toPromise();
  }

}
