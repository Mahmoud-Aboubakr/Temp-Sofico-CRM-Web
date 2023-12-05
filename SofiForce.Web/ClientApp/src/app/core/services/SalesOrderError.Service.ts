import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { SalesOrderErrorListModel } from '../Models/ListModels/SalesOrderErrorListModel';


@Injectable({
  providedIn: 'root'
})
export class SalesOrderErrorService {
  constructor(private _http: HttpClient) { }

  public GetBySalesId = async (Id) => {
    return this._http.get<ResponseModel<SalesOrderErrorListModel[]>>("SalesOrderError/getBySalesId?Id="+Id).toPromise();
  }
}
