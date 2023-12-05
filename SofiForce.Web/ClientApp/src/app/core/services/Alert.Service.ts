import { Injectable } from '@angular/core';
import { AppMessageService } from './AppMessage.Service';
import { MessageService } from 'primeng/api';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class AlertService {
  constructor(    
    private messageService: MessageService,) { 
      
    }
  public Show = (severity,detail) => {

    this.messageService.add({severity:severity, summary: 'Error', detail: detail});
    
  }


}
