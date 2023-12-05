import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';

import { AppUserStoreModel } from '../Models/EntityModels/appUserStoreModel';
import { AppUserStoreListModel } from '../Models/ListModels/AppUserStoreListModel';

@Injectable({
  providedIn: 'root'
})
export class AppUserStoreService {
  constructor(private _http: HttpClient) { }


  public Save = async (model) => {
    return this._http.post<ResponseModel<AppUserStoreModel>>("AppUserStore/Save",model).toPromise();
  }

  public Delete = async (model) => {
    return this._http.post<ResponseModel<AppUserStoreModel>>("AppUserStore/Delete",model).toPromise();
  }
  public GetByUser = async (Id) => {
    return this._http.get<ResponseModel<AppUserStoreListModel[]>>("AppUserStore/getByUser?Id="+Id).toPromise();
  }
}
