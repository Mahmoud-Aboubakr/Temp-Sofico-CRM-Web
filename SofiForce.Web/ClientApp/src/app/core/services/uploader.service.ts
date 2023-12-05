import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FileModel } from "../Models/DtoModels/FileModel";
import { ResponseModel } from "../Models/ResponseModels/ResponseModel";


@Injectable({
  providedIn: 'root'
})
export class UploaderService {


  constructor(private _http: HttpClient) { }


  public Upload = async (file)  => {

    let formData:FormData = new FormData();
    formData.append('uploadFile', file, file.name);
    let _headers = new HttpHeaders();
    _headers.append('Content-Type', 'multipart/form-data');
    _headers.append('Accept', 'application/json');

    return this._http.post<ResponseModel<FileModel>>("Uploader/add", formData, { headers: _headers }).toPromise()
  }
}