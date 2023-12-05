import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ClientQuotaListModel } from '../Models/ListModels/ClientQuotaListModel';
import { ClientQuotaHistoryListModel } from '../Models/ListModels/ClientQuotaHistoryListModel';

@Injectable({
  providedIn: 'root'
})
export class ClientQuotaService {
  constructor(private _http: HttpClient) { }

  public getHistory = async (clientId, itemId) => {
    return this._http.get<ResponseModel<ClientQuotaHistoryListModel[]>>("ClientQuota/getHistory", { params: { clientId: clientId, itemId: itemId } }).toPromise();
  }
}
