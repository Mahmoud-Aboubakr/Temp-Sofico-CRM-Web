import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { SalesOrderMessagesListModel } from '../Models/ListModels/SalesOrderMessagesListModel';
import { SalesOrderMessagesModel } from '../Models/EntityModels/SalesOrderMessagesModel';

@Injectable({
  providedIn: 'root'
})
export class SalesOrderMessageService {
  constructor(private _http: HttpClient) { }


  public GetMessages = async (Id) => {
    return this._http.get<ResponseModel<SalesOrderMessagesListModel[]>>("SalesOrderMessage/getMessages?Id="+Id).toPromise();
  }


  public Save = async (model) => {
    return this._http.post<ResponseModel<SalesOrderMessagesListModel[]>>("SalesOrderMessage/Save", model).toPromise();
  }

}
