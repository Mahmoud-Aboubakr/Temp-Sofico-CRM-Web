import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { AppUserClientGroupModel } from '../Models/EntityModels/AppUserClientGroupModel';
import { AppUserClientGroupListModel } from '../Models/ListModels/AppUserClientGroupListModel';

@Injectable({
  providedIn: 'root'
})
export class AppUserGroupService {
  constructor(private _http: HttpClient) { }


  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("AppUserGroup/GetAll").toPromise();
  }


}
