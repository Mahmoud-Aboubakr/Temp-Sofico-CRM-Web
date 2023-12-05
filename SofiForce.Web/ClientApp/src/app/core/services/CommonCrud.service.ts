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
    return this._http.get<ResponseModel<typeof data>>(url); //"Lockup/" + url
  }

  public update = (url:string,body: any,data:any) => {
    return this._http.put<ResponseModel<typeof data>>(url, body);  //"Lockup/"+id
  }
}
