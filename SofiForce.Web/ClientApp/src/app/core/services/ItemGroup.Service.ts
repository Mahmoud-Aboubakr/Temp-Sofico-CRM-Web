import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ItemGroupListModel } from '../Models/ListModels/ItemGroupListModel';

@Injectable({
  providedIn: 'root'
})
export class ItemGroupService {
  constructor(private _http: HttpClient) { }
  
  public Filter = async (model) => {
    return this._http.post<ResponseModel<ItemGroupListModel[]>>("ItemGroup/filter", model).toPromise();
  }
}
