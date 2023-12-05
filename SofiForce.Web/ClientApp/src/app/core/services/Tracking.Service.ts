import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { TrakingRepresentativeModel } from '../Models/DtoModels/TrakingRepresentativeModel';

import { KBISummeryModel } from '../Models/StatisticalModels/SummeryDetailModel';
import { TrakingRepresentativeDetailModel } from '../Models/ListModels/TrakingRepresentativeDetailModel';

@Injectable({
  providedIn: 'root'
})
export class TrackingService {
  constructor(private _http: HttpClient) { }
  

  public getRepresentative = async (model) => {
    return this._http.post<ResponseModel<TrakingRepresentativeModel[]>>("Tracking/representative",model).toPromise();
  }
  public getSummery = async (Id,mode) => {
    return this._http.get<ResponseModel<KBISummeryModel>>("Tracking/summery?Id="+Id+"&mode="+mode).toPromise();
  }
  public getDetails = async (model) => {
    return this._http.post<ResponseModel<TrakingRepresentativeDetailModel[]>>("Tracking/details",model).toPromise();
  }

}
