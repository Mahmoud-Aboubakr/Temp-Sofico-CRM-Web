import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { SalesOrderLogListModel } from '../Models/ListModels/SalesOrderLogListModel';

@Injectable({
  providedIn: 'root'
})
export class SalesOrderLogService {
  constructor(private _http: HttpClient) { }


  public GetById = async (SalesId) => {
    return this._http.get<ResponseModel<SalesOrderLogListModel[]>>("SalesOrderLog/getbyId?SalesId="+SalesId).toPromise();
  }

}
