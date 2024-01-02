import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { catchError, tap } from "rxjs/operators";
import { throwError } from "rxjs";
import { Router } from "@angular/router";


@Injectable({
  providedIn: 'root'
})
export class CommonCrudService {


  constructor(private _http: HttpClient,private _router: Router) { }

  public post = (url:string,body: any,data:any) => {

    return this._http.post<ResponseModel<typeof data>>(url, body)
    .pipe(
      tap((response: any) => {   if (response.statusCode == 401) {
                this._router.navigateByUrl("/auth/login");
               }
      }))
      .toPromise(); 
    }

  public delete = (url: string) => {
    return this._http.delete<ResponseModel<boolean>>(url);
  }

  public get = (url: string,data:any) => {
    return this._http.get<ResponseModel<typeof data>>(url)
    .pipe(
      tap((response: any) => {   if (response.statusCode == 401) {
                this._router.navigateByUrl("/auth/login");
               }
      }))
    .toPromise();
  }
  public postFile = (url: string,model:any) => {
    return this._http.post(url, model,{
      reportProgress: true,
      responseType: 'blob'
    }).pipe(
      tap((response: any) => {   if (response.statusCode == 401) {
                this._router.navigateByUrl("/auth/login");
               }
      }));
  }
  public  getFile = (url: string) => {
    return this._http.get(url,{
      reportProgress: true,
      responseType: 'blob'
    }).pipe(
      tap((response: any) => {   if (response.statusCode == 401) {
                this._router.navigateByUrl("/auth/login");
               }
      }));
  }
  public postFileWithFormData = async (file,Id,url:string,data:any)  => {

    let formData:FormData = new FormData();
    formData.append('uploadFile', file, file.name);
    formData.append('id', Id);
    let _headers = new HttpHeaders();
    _headers.append('Content-Type', 'multipart/form-data');
    _headers.append('Accept', 'application/json');

    return this._http.post<ResponseModel<typeof data>>(url, formData, { headers: _headers }).pipe(
      tap((response: any) => {   if (response.statusCode == 401) {
                this._router.navigateByUrl("/auth/login");
               }
      })).toPromise()
  }
  public parseFile = async (file,url:string,data:any)  => {

    let formData:FormData = new FormData();
    formData.append('uploadFile', file, file.name);
    let _headers = new HttpHeaders();
    _headers.append('Content-Type', 'multipart/form-data');
    _headers.append('Accept', 'application/json');

    return this._http.post<ResponseModel<typeof data >>(url, formData, { headers: _headers }).pipe(
      tap((response: any) => {   if (response.statusCode == 401) {
                this._router.navigateByUrl("/auth/login");
               }
      })).toPromise()
  }
  public update = (url:string,body: any,data:any) => {
    return this._http.put<ResponseModel<typeof data>>(url, body);  //"Lockup/"+id
  }
  public getWithParam = async (url: string,params:any,data:any) => {
    return this._http.get<ResponseModel<typeof data>>(url, { params: { params} }).pipe(
      tap((response: any) => {   if (response.statusCode == 401) {
                this._router.navigateByUrl("/auth/login");
               }
      })).toPromise();
  }
}
