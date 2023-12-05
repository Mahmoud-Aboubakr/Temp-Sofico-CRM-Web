import { NgModule } from '@angular/core';
import { CdTimerModule } from 'angular-cd-timer';
@NgModule({
    imports: [
        CdTimerModule
    ],
    exports:[
        CdTimerModule
    ],
    //...
})
export class UtilCommon { }