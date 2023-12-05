import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ResponseModel } from '../../Models/ResponseModels/ResponseModel';
import { LookupModel } from '../../Models/DtoModels/lookupModel';
import { PromotionCriteriaAttrCustomModel } from '../../Models/EntityModels/PromotionCriteriaAttrCustomModel';
import { PromotionCriteriaAttrModel } from '../../Models/EntityModels/PromotionCriteriaAttrModel';
import { PromotionCriteriaAttrCustomListModel } from '../../Models/ListModels/PromotionCriteriaAttrCustomListModel';


@Injectable({
  providedIn: 'root'
})
export class PromotionCriteriaAttrCustomService {
  constructor(private _http: HttpClient) { }



  public Save = async (model) => {
    return this._http.post<ResponseModel<PromotionCriteriaAttrCustomModel>>("PromotionCriteriaAttrCustom/Save", model).toPromise();
  }

  public Delete = async (model) => {
    return this._http.post<ResponseModel<PromotionCriteriaAttrCustomModel>>("PromotionCriteriaAttrCustom/Delete", model).toPromise();
  }

  public getByAttribute = async (Id) => {
    return this._http.get<ResponseModel<PromotionCriteriaAttrCustomListModel[]>>("PromotionCriteriaAttrCustom/getByAttribute?Id="+Id).toPromise();
  }

  public Upload = async (file,Id)  => {

    let formData:FormData = new FormData();
    formData.append('uploadFile', file, file.name);
    formData.append('id', Id);
    let _headers = new HttpHeaders();
    _headers.append('Content-Type', 'multipart/form-data');
    _headers.append('Accept', 'application/json');

    return this._http.post<ResponseModel<PromotionCriteriaAttrCustomModel[]>>("PromotionCriteriaAttrCustom/upload", formData, { headers: _headers }).toPromise()
  }

  public Download = (model)  => {
    return this._http.post("PromotionCriteriaAttrCustom/download", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }

  public DeleteAllItem = async (model) => {
    return this._http.post<ResponseModel<PromotionCriteriaAttrModel>>("PromotionCriteriaAttrCustom/DeleteAll", model).toPromise();
  }
  

}
