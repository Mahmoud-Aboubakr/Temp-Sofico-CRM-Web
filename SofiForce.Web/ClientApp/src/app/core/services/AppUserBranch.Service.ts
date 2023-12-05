import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { AppUserBranchModel } from '../Models/EntityModels/appUserBranchModel';
import { AppUserBranchListModel } from '../Models/ListModels/AppUserBranchListModel';

@Injectable({
  providedIn: 'root'
})
export class AppUserBranchService {
  constructor(private _http: HttpClient) { }


  public Save = async (model) => {
    return this._http.post<ResponseModel<AppUserBranchModel>>("AppUserBranch/Save",model).toPromise();
  }

  public Delete = async (model) => {
    return this._http.post<ResponseModel<AppUserBranchModel>>("AppUserBranch/Delete",model).toPromise();
  }
  public GetByUser = async (Id) => {
    return this._http.get<ResponseModel<AppUserBranchListModel[]>>("AppUserBranch/getByUser?Id="+Id).toPromise();
  }
}
