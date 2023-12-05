import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { StoreListModel } from '../Models/ListModels/StoreListModel';
import { StoreModel } from '../Models/EntityModels/storeModel';


@Injectable({
  providedIn: 'root'
})
export class StoreService {
  constructor(private _http: HttpClient) { }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<StoreListModel[]>>("Store/Filter", model).toPromise();
  }

  public getById = async (Id) => {
    return this._http.get<ResponseModel<StoreModel>>("Store/getById?Id="+Id).toPromise();
  }
}
