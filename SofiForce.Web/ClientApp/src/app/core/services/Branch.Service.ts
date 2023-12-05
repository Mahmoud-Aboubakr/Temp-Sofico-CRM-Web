import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { BranchListModel } from '../Models/ListModels/BranchListModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { BranchModel } from '../Models/EntityModels/branchModel';

@Injectable({
  providedIn: 'root'
})
export class BranchService {
  constructor(private _http: HttpClient) { }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<BranchListModel[]>>("Branch/Filter", model).toPromise();
  }
  public GetByid = async (Id) => {
    return this._http.get<ResponseModel<BranchModel>>("Branch/GetByid?Id="+Id).toPromise();
  }

  public Save = async (model) => {
    return this._http.post<ResponseModel<BranchModel>>("Branch/Save", model).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<BranchModel>>("Branch/Delete", model).toPromise();
  }
  public Export = (model)  => {
    return this._http.post("Branch/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
}
