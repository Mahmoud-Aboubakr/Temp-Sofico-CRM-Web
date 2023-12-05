import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ClientStatisticalModel } from '../Models/StatisticalModels/ClientStatisticalModel';


@Injectable({
  providedIn: 'root'
})
export class DashboardSalesClientService {
  constructor(private _http: HttpClient) { }

  public GetALL = async (model) => {
    return this._http.post<ResponseModel<ClientStatisticalModel>>("DashboardSalesClient/all",model).toPromise();
  }
}
