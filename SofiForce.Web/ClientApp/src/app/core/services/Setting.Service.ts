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
import { WebSetting } from '../Models/EntityModels/WebSetting';


@Injectable({
  providedIn: 'root'
})
export class SettingService {
  constructor(private _http: HttpClient) { }


  public WebSetting = async () => {
    return this._http.get<ResponseModel<WebSetting>>("Setting/WebSetting").toPromise();
  }


  
}
