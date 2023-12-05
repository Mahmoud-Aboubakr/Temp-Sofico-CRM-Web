import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { SalesBranchControlModel } from '../Models/StatisticalModels/SalesBranchControlModel';
import { SalesSupervisorControlModel } from '../Models/StatisticalModels/SalesSupervisorControlModel';
import { PerformanceSalesmanModel } from '../Models/StatisticalModels/PerformanceSalesmanModel';
import { PerformanceClientModel } from '../Models/StatisticalModels/SalesClientControlModel';

@Injectable({
  providedIn: 'root'
})
export class SalesControlService {
  constructor(private _http: HttpClient) { }
  
  public getBranch = async (model) => {
    return this._http.post<ResponseModel<SalesBranchControlModel>>("SalesControl/branch",model).toPromise();
  }
  public getSupervisor = async (model) => {
    return this._http.post<ResponseModel<SalesSupervisorControlModel>>("SalesControl/supervisor",model).toPromise();
  }
  public getRepresentative = async (model) => {
    return this._http.post<ResponseModel<PerformanceSalesmanModel[]>>("SalesControl/representative",model).toPromise();
  }

  public getClient = async (model) => {
    return this._http.post<ResponseModel<PerformanceClientModel>>("SalesControl/client",model).toPromise();
  }

  public branchExport = (model)  => {
    return this._http.post("SalesControl/branchExport", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
  public supervisorExport = (model)  => {
    return this._http.post("SalesControl/supervisorExport", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
  public representativeExport = (model)  => {
    return this._http.post("SalesControl/representativeExport", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
  public clientExport = (model)  => {
    return this._http.post("SalesControl/clientExport", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
}
