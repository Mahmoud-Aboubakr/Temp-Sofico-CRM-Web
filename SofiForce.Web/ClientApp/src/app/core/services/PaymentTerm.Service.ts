import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
import { PaymentTermListModel } from '../Models/ListModels/PaymentTermListModel';

@Injectable({
  providedIn: 'root'
})
export class PaymentTermService {
  constructor(private _http: HttpClient) { }


  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("PaymentTerm/GetAll").toPromise();
  }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<PaymentTermListModel[]>>("PaymentTerm/Filter", model).toPromise();
  }

}
