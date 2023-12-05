import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { AppUserModel } from '../Models/EntityModels/appUserModel';
import { AppUserListModel } from '../Models/ListModels/AppUserListModel';

@Injectable({
  providedIn: 'root'
})
export class AppUserService {
  constructor(private _http: HttpClient) { }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<AppUserListModel[]>>("AppUser/Filter",model).toPromise();
  }
  
  public Save = async (model) => {
    return this._http.post<ResponseModel<AppUserModel>>("AppUser/Save",model).toPromise();
  }

  public Delete = async (model) => {
    return this._http.post<ResponseModel<AppUserModel>>("AppUser/Delete",model).toPromise();
  }

  public Activate = async (model) => {
    return this._http.post<ResponseModel<AppUserModel>>("AppUser/activate",model).toPromise();
  }

  public DeActivate = async (model) => {
    return this._http.post<ResponseModel<AppUserModel>>("AppUser/deActivate",model).toPromise();
  }

  public Logout = async (model) => {
    return this._http.post<ResponseModel<AppUserModel>>("AppUser/logout",model).toPromise();
  }

  public ResetPassword = async (model) => {
    return this._http.post<ResponseModel<AppUserModel>>("AppUser/resetPassword",model).toPromise();
  }

  public GetById = async (Id) => {
    return this._http.get<ResponseModel<AppUserModel>>("AppUser/GetById?Id="+Id).toPromise();
  }

}
