import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { BranchListModel } from '../Models/ListModels/BranchListModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { BranchModel } from '../Models/EntityModels/branchModel';
import { SyncSetupDetailModel } from '../Models/EntityModels/SyncSetupDetailModel';

@Injectable({
  providedIn: 'root'
})
export class SyncSetupDetailService {
  constructor(private _http: HttpClient) { }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<SyncSetupDetailModel[]>>("SyncSetupDetail/Filter", model).toPromise();
  }
 
  public Save = async (model) => {
    return this._http.post<ResponseModel<SyncSetupDetailModel>>("SyncSetupDetail/Save", model).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<SyncSetupDetailModel>>("SyncSetupDetail/Delete", model).toPromise();
  }
}
