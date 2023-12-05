import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class AppMessageService {
    MESSAGE_OK = '';
    MESSAGE_ERROR='';
    MESSAGE_CONFIRM='';
    MESSAGE_INVALID='';
  
  constructor(private _translateService: TranslateService,) { 
    this._translateService.get('Information Successfully Saved').subscribe((res) => { this.MESSAGE_OK = res });
    this._translateService.get('Error Saving Information').subscribe((res) => { this.MESSAGE_ERROR = res });
    this._translateService.get('Are you sure that you want to proceed?').subscribe((res) => { this.MESSAGE_CONFIRM = res });
    this._translateService.get('Invalid data, please fill missing data and try again !').subscribe((res) => { this.MESSAGE_INVALID = res });

  }
}
