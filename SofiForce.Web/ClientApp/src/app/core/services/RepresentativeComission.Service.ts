import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';

import { RepresentativeComissionModel } from '../Models/EntityModels/RepresentativeComissionModel';
import { RepresentativeComissionListModel } from '../Models/ListModels/RepresentativeComissionListModel';

@Injectable({
  providedIn: 'root'
})
export class RepresentativeComissionService {
  constructor(private _http: HttpClient) { }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<RepresentativeComissionListModel[]>>("RepresentativeComission/Filter", model).toPromise();
  }
  public Save = async (model) => {
    return this._http.post<ResponseModel<RepresentativeComissionModel>>("RepresentativeComission/Save", model).toPromise();
  }
  
  public getById = async (Id) => {
    return this._http.get<ResponseModel<RepresentativeComissionModel>>("RepresentativeComission/getById?Id="+Id).toPromise();
  }

  public getByRepresentative = async (Id) => {
    return this._http.get<ResponseModel<RepresentativeComissionListModel[]>>("RepresentativeComission/getByRepresentative?Id="+Id).toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<RepresentativeComissionModel>>("RepresentativeComission/Delete", model).toPromise();
  }
  public Approve = async (model) => {
    return this._http.post<ResponseModel<RepresentativeComissionModel>>("RepresentativeComission/approve", model).toPromise();
  }


  public Export = (model)  => {
    return this._http.post("RepresentativeComission/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
  
}
