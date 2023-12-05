import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ResponseModel } from '../../Models/ResponseModels/ResponseModel';
import { PromtionCriteriaClientAttrCustomModel } from '../../Models/EntityModels/PromtionCriteriaClientAttrCustomModel';
import { PromtionCriteriaClientAttrCustomListModel } from '../../Models/ListModels/PromtionCriteriaClientAttrCustomListModel';
import { PromtionCriteriaClientAttrModel } from '../../Models/EntityModels/PromtionCriteriaClientAttrModel';


@Injectable({
  providedIn: 'root'
})
export class PromtionCriteriaClientAttrCustomService {
  constructor(private _http: HttpClient) { }



  public Save = async (model) => {
    return this._http.post<ResponseModel<PromtionCriteriaClientAttrCustomModel>>("PromtionCriteriaClientAttrCustom/Save", model).toPromise();
  }
  
  public Upload = async (file,Id)  => {

    let formData:FormData = new FormData();
    formData.append('uploadFile', file, file.name);
    formData.append('id', Id);
    let _headers = new HttpHeaders();
    _headers.append('Content-Type', 'multipart/form-data');
    _headers.append('Accept', 'application/json');

    return this._http.post<ResponseModel<PromtionCriteriaClientAttrCustomModel[]>>("PromtionCriteriaClientAttrCustom/upload", formData, { headers: _headers }).toPromise()
  }

  public Download = (model)  => {
    return this._http.post("PromtionCriteriaClientAttrCustom/download", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }

  public DeleteAllClient = async (model) => {
    return this._http.post<ResponseModel<PromtionCriteriaClientAttrModel>>("PromtionCriteriaClientAttrCustom/DeleteAll", model).toPromise();
  }
  
  
  public getByAttribute = async (Id) => {
    return this._http.get<ResponseModel<PromtionCriteriaClientAttrCustomListModel[]>>("PromtionCriteriaClientAttrCustom/getByAttribute?Id="+Id).toPromise();
  }


  public getByClient = async (Id) => {
    return this._http.get<ResponseModel<PromtionCriteriaClientAttrCustomListModel[]>>("PromtionCriteriaClientAttrCustom/getByClient?Id="+Id).toPromise();
  }


  public Delete = async (model) => {
    return this._http.post<ResponseModel<PromtionCriteriaClientAttrCustomModel>>("PromtionCriteriaClientAttrCustom/Delete", model).toPromise();
  }

}
