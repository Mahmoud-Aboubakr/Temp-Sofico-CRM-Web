import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ItemStoreListModel } from '../Models/ListModels/ItemStoreListModel';
import { ItemStoreTotalListModel } from '../Models/ListModels/ItemStoreTotalListModel';


@Injectable({
  providedIn: 'root'
})
export class ItemStoreTotalService {
  constructor(private _http: HttpClient) { }
  
  public Filter = async (model) => {
    return this._http.post<ResponseModel<ItemStoreTotalListModel[]>>("ItemStoreTotal/filter",model).toPromise();
  }

}
