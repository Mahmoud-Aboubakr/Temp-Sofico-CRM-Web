import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ItemQuotaListModel } from '../Models/ListModels/ItemQuotaListModel';

@Injectable({
  providedIn: 'root'
})
export class ItemQuotaService {
  constructor(private _http: HttpClient) { }
  
  public Filter = async (model) => {
    return this._http.post<ResponseModel<ItemQuotaListModel[]>>("ItemQuota/filter", model).toPromise();
  }
}
