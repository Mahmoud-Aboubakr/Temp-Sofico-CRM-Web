import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { MyPlanModel } from '../Models/StatisticalModels/MyPlanModel';

@Injectable({
  providedIn: 'root'
})
export class MyPlanService {
  constructor(private _http: HttpClient) { }
  
  public getMyPlan = async (model) => {
    return this._http.post<ResponseModel<MyPlanModel>>("MyPlan/getMyPlan",model).toPromise();
  }

  public export = (model)  => {
    return this._http.post("MyPlan/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
}
