import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../../Models/DtoModels/lookupModel';
import { PromotionModel } from '../../Models/EntityModels/PromotionModel';
import { BooleanModel } from '../../Models/DtoModels/BooleanModel';
import { supplementaryUploadDtoModel } from '../../Models/DtoModels/FilePathModel';
import { SalesOrderPromotionAllListModel } from '../../Models/EntityModels/SalesOrderPromotionAllListModel';


@Injectable({
  providedIn: 'root'
})
export class PromotionService {
  constructor(private _http: HttpClient) { }


  public Filter = async (model) => {
    return this._http.post<ResponseModel<PromotionModel[]>>("Promotion/filter", model).toPromise();
  }

  public OrderPromotion = async (model) => {
    return this._http.post<ResponseModel<SalesOrderPromotionAllListModel[]>>("Promotion/OrderPromotion", model).toPromise();
  }
 


  public Save = async (model) => {
    return this._http.post<ResponseModel<PromotionModel>>("Promotion/Save", model).toPromise();
  }

  public Upload = async (model) => {
    return this._http.post<ResponseModel<supplementaryUploadDtoModel>>("Promotion/Upload", model).toPromise();
  }

  public Activate = async (model) => {
    return this._http.post<ResponseModel<PromotionModel>>("Promotion/activate", model).toPromise();
  }
  public DeActivate = async (model) => {
    return this._http.post<ResponseModel<PromotionModel>>("Promotion/deActivate", model).toPromise();
  }
  public Extend = async (model) => {
    return this._http.post<ResponseModel<PromotionModel>>("Promotion/extend", model).toPromise();
  }

  public Delete = async (model) => {
    return this._http.post<ResponseModel<PromotionModel>>("Promotion/Delete", model).toPromise();
  }

  public Copy = async (model) => {
    return this._http.post<ResponseModel<PromotionModel>>("Promotion/copy", model).toPromise();
  }

  public GetById = async (Id) => {
    return this._http.get<ResponseModel<PromotionModel>>("Promotion/getById?Id="+Id).toPromise();
  }

  public Exists = async (model) => {
    return this._http.post<ResponseModel<PromotionModel>>("Promotion/exists",model).toPromise();
  }


  public  Template1= async () => {
    return this._http.get("Promotion/template1",{
      reportProgress: true,
      responseType: 'blob'
    });
  }

  public OrderPromotionDownload = (model)  => {
    return this._http.post("Promotion/OrderPromotionDownload", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
}
