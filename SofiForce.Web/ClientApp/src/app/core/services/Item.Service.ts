import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ItemListModel } from '../Models/ListModels/ItemListModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { ItemPromotionAllListModel } from '../Models/ListModels/ItemPromotionAllListModel';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  constructor(private _http: HttpClient) { }
  
  public Filter = async (model) => {
    return this._http.post<ResponseModel<ItemListModel[]>>("Item/filter", model).toPromise();
  }
  public FilterAll = async (model) => {
    return this._http.post<ResponseModel<ItemListModel[]>>("Item/filterAll", model).toPromise();
  }

  public ItemPromotion = async (model) => {
    return this._http.post<ResponseModel<ItemPromotionAllListModel[]>>("Item/ItemPromotion", model).toPromise();
  }

  public AutoComplete = async (query) => {
    return this._http.get<ResponseModel<LookupModel[]>>("Item/AutoComplete?query="+query).toPromise();
  }

  public ItemPromotionDownload = (model)  => {
    return this._http.post("Item/itemPromotionDownload", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
}
