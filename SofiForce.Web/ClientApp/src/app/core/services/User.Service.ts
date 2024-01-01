import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { UserModel } from '../Models/DtoModels/UserModel';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private _http: HttpClient) { }
  

  onAuthorizationChange=new Subject();

  public IsAuthorized = () => {
    if(localStorage.getItem('sfc_token')==null)
      return false;
    else
      return true;
  }

  public Current = () :UserModel => {
    if(localStorage.getItem('user')!=null)
    {
       return JSON.parse(localStorage.getItem('user'))
    }
    else{
      return null;
    }

  }

  // public Login = async (model) => {
  //   return this._http.post<ResponseModel<UserModel>>("Users/Auth",model).toPromise();
  // }
  // public ResetPassword = async (model) => {
  //   return this._http.post<ResponseModel<UserModel>>("Users/ResetPassword",model).toPromise();
  // }

  // public Update = async (model) => {
  //   return this._http.post<ResponseModel<UserModel>>("Users/update",model).toPromise();
  // }

  // public UpdateDefault = async (model) => {
  //   return this._http.post<ResponseModel<UserModel>>("Users/updateDefault",model).toPromise();
  // }

  // public getById = async (Id) => {
  //   return this._http.get<ResponseModel<AppUserModel>>("Users/getById?Id="+Id).toPromise();
  // }

  // public Save = async (model) => {
  //   return this._http.post<ResponseModel<AppUserModel>>("Users/save",model).toPromise();
  //}
}
