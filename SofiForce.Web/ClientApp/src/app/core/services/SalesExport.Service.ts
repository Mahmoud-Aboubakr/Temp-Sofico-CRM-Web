import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { ExportModel } from '../Models/DtoModels/ExportModel';

@Injectable({
  providedIn: 'root'
})
export class SalesExportService {
  constructor(private _http: HttpClient) { }

  public ExportInvoiceHeader = async (model) => {
    return this._http.post<ResponseModel<ExportModel>>("SalesExport/invoiceHeader", model).toPromise();
  }
  public ExportInvoiceDetail = async (model) => {
    return this._http.post<ResponseModel<ExportModel>>("SalesExport/invoiceDetail", model).toPromise();
  }


}
