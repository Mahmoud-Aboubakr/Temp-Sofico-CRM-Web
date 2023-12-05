import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { OrderMonitorModel } from '../Models/StatisticalModels/OrderMonitorModel';

@Injectable({
  providedIn: 'root'
})
export class OrderMonitorService {
  constructor(private _http: HttpClient) { }
  
  public getMonitor = async (model) => {
    return this._http.post<ResponseModel<OrderMonitorModel>>("OrderMonitor/getMonitor",model).toPromise();
  }
  
}
