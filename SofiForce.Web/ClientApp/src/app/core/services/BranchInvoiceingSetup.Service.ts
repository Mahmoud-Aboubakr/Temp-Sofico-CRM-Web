import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { BranchListModel } from '../Models/ListModels/BranchListModel';
import { BranchInvoiceingSetupModel } from '../Models/EntityModels/BranchInvoiceingSetupModel';
import { BranchInvoiceingSetupListModel } from '../Models/ListModels/BranchInvoiceingSetupListModel';

@Injectable({
  providedIn: 'root'
})
export class BranchInvoiceingSetupService {
  constructor(private _http: HttpClient) { }

  public Filter = async (model) => {
    return this._http.post<ResponseModel<BranchInvoiceingSetupListModel[]>>("BranchInvoiceingSetup/Filter", model).toPromise();
  }
  public GetByid = async (Id) => {
    return this._http.get<ResponseModel<BranchInvoiceingSetupModel>>("BranchInvoiceingSetup/GetByid?Id="+Id).toPromise();
  }

  public Save = async (model) => {
    return this._http.post<ResponseModel<BranchInvoiceingSetupModel>>("BranchInvoiceingSetup/Save", model).toPromise();
  }

  public EnableAll = async () => {
    return this._http.get<ResponseModel<BranchInvoiceingSetupModel>>("BranchInvoiceingSetup/enableAll").toPromise();
  }
  public DisableAll = async () => {
    return this._http.get<ResponseModel<BranchInvoiceingSetupModel>>("BranchInvoiceingSetup/disableAll").toPromise();
  }
  public Delete = async (model) => {
    return this._http.post<ResponseModel<BranchInvoiceingSetupModel>>("BranchInvoiceingSetup/Delete", model).toPromise();
  }
  public Export = (model)  => {
    return this._http.post("BranchInvoiceingSetup/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
}
