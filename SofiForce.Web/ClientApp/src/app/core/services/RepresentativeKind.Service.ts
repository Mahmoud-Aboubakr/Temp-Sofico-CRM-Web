import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { SupervisorListModel } from '../Models/ListModels/SupervisorListModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';
// import { SupervisorModel } from '../Models/EntityModels/supervisorModel';

@Injectable({
  providedIn: 'root'
})
export class RepresentativeKindService {
  constructor(private _http: HttpClient) { }


  public GetAll = async () => {
    return this._http.get<ResponseModel<LookupModel[]>>("RepresentativeKind/GetAll").toPromise();
  }

}
