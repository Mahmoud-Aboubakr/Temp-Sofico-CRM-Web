import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { DashboardSalesModel } from '../Models/StatisticalModels/DashboardModel';


@Injectable({
  providedIn: 'root'
})
export class DashboardSalesService {
  constructor(private _http: HttpClient) { }

  public GetDashboard = async (model) => {
    return this._http.post<ResponseModel<DashboardSalesModel>>("DashboardSales/all",model).toPromise();
  }

  public GetChartLine = async (model) => {
    return this._http.post<ResponseModel<DashboardSalesModel>>("DashboardSales/ChartLine",model).toPromise();
  }
  public GetKBI = async (model) => {
    return this._http.post<ResponseModel<DashboardSalesModel>>("DashboardSales/salesKBI",model).toPromise();
  }

  
}
