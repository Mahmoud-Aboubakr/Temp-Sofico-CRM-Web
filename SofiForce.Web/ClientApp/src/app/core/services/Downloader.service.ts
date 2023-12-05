import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";



@Injectable({
  providedIn: 'root'
})
export class DownloaderService {


  constructor(private _http: HttpClient) { }


  public DownloadExcel = async (file)  => {
    return this._http.get("downloader/excel?file="+file,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
}