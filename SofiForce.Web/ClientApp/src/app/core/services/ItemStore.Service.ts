import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ItemStoreListModel } from '../Models/ListModels/ItemStoreListModel';


@Injectable({
  providedIn: 'root'
})
export class ItemStoreService {
  constructor(private _http: HttpClient) { }
  
  public Filter = async (model) => {
    return this._http.post<ResponseModel<ItemStoreListModel[]>>("ItemStore/filter",model).toPromise();
  }

}
