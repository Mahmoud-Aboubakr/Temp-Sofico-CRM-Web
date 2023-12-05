import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { VendorListModel } from '../Models/ListModels/VendorListModel';

@Injectable({
  providedIn: 'root'
})
export class VendorService {
  constructor(private _http: HttpClient) { }
  
  public Filter = async (model) => {
    return this._http.post<ResponseModel<VendorListModel[]>>("Vendor/filter", model).toPromise();
  }
}
