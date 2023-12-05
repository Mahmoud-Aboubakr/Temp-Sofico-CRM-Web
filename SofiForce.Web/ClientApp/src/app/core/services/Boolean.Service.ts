import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { BranchListModel } from '../Models/ListModels/BranchListModel';
import { LookupModel } from '../Models/DtoModels/lookupModel';


@Injectable({
  providedIn: 'root'
})
export class BooleanService {
  constructor(private _http: HttpClient) { }

  public GetAll = async (lan) => {
    let list:LookupModel[]=[];
    if(lan=='ar'){
        list.push({id:0,code:'0',name:'--'});
        list.push({id:1,code:'1',name:'نعم'});
        list.push({id:2,code:'2',name:'لا'});
    }
    else
    {
        list.push({id:0,code:'0',name:'--'});
        list.push({id:1,code:'1',name:'Yes'});
        list.push({id:2,code:'2',name:'No'});
    }

    return list;
  }
  
}
