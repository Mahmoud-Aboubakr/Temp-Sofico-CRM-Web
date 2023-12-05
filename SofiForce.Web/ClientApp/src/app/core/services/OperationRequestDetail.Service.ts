import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { OperationRequestDetailListModel } from '../Models/ListModels/OperationRequestDetailListModel';
import { OperationRequestDetailModel } from '../Models/EntityModels/OperationRequestDetailModel';
import { OperationRequestDetailRejectModel } from '../Models/DtoModels/OperationRequestDetailRejectModel';
import { OperationRequestDetailApproveModel } from '../Models/DtoModels/OperationRequestDetailApproveModel';
import { OperationRequestDetailCodedModel } from '../Models/DtoModels/OperationRequestDetailCodedModel';
import { OperationRequestDetailAddModel } from '../Models/DtoModels/OperationRequestDetailAddModel';
import { GeoPoint } from '../Models/DtoModels/GeoPoint';


@Injectable({
  providedIn: 'root'
})
export class OperationRequestDetailService {
  constructor(private _http: HttpClient) { }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<OperationRequestDetailListModel[]>>("OperationRequestDetail/Filter", model).toPromise();
  }
  
  public Save = async (model) => {
    return this._http.post<ResponseModel<OperationRequestDetailModel>>("OperationRequestDetail/Save", model).toPromise();
  }
  public getById = async (Id) => {
    return this._http.get<ResponseModel<OperationRequestDetailModel>>("OperationRequestDetail/getById?Id="+Id).toPromise();
  }

  public getPoints = async (Id) => {
    return this._http.get<ResponseModel<GeoPoint[]>>("OperationRequestDetail/getPoints?Id="+Id).toPromise();
  }
  
  public Delete = async (model) => {
    return this._http.post<ResponseModel<OperationRequestDetailModel>>("OperationRequestDetail/Delete", model).toPromise();
  }
  public Add = async (model) => {
    return this._http.post<ResponseModel<OperationRequestDetailAddModel>>("OperationRequestDetail/Add", model).toPromise();
  }
  public reject = async (model) => {
    return this._http.post<ResponseModel<OperationRequestDetailRejectModel>>("OperationRequestDetail/reject", model).toPromise();
  }

  public coded = async (model) => {
    return this._http.post<ResponseModel<OperationRequestDetailCodedModel>>("OperationRequestDetail/coded", model).toPromise();
  }

  public approve = async (model) => {
    return this._http.post<ResponseModel<OperationRequestDetailApproveModel>>("OperationRequestDetail/approve", model).toPromise();
  }


  public Export = (model)  => {
    return this._http.post("OperationRequestDetail/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }

  
}
