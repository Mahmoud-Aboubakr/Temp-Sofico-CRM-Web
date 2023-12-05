import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ResponseModel } from '../Models/ResponseModels/ResponseModel';
import { NotificationModel } from '../Models/EntityModels/NotificationModel';
import { NotificationListModel } from '../Models/ListModels/NotificationListModel';
import { UserNotificationListModel } from '../Models/ListModels/UserNotificationListModel';
import { Subject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  constructor(private _http: HttpClient) { }

  notificationCount=new Subject<number>();

  public Filter = async (model) => {
    return this._http.post<ResponseModel<NotificationListModel[]>>("Notification/Filter", model).toPromise();
  }
  public My = async (model) => {
    return this._http.post<ResponseModel<UserNotificationListModel[]>>("Notification/My", model).toPromise();
  }
  
  public Save = async (model) => {
    return this._http.post<ResponseModel<NotificationModel>>("Notification/Save", model).toPromise();
  }

  public getById = async (Id) => {
    return this._http.get<ResponseModel<NotificationModel>>("Notification/getById?Id="+Id).toPromise();
  }

  public Delete = async (model) => {
    return this._http.post<ResponseModel<NotificationModel>>("Notification/Delete", model).toPromise();
  }

  public MarkAsRead = async (model) => {
    return this._http.post<ResponseModel<NotificationModel>>("Notification/markAsRead", model).toPromise();
  }

  public Export = (model)  => {
    return this._http.post("Notification/Export", model,{
      reportProgress: true,
      responseType: 'blob'
    });
  }
  
}
