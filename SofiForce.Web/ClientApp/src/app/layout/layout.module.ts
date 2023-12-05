import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { NgprimeCommon } from '../core/Common/ngprime.common';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { PipeModule } from '../core/Pipes/pipe.module';
import { AppLoaderComponent } from './app-loader/app-loader.component';
import { LeftmenuComponent } from './leftmenu/leftmenu.component';



@NgModule({
    declarations: [
        LeftmenuComponent,
        AppLoaderComponent,
    ],
    imports: [
        CommonModule,
        NgprimeCommon,
        PipeModule,
        CollapseModule,
        TranslateModule.forRoot(),
    ],
    exports:[
        LeftmenuComponent,
        AppLoaderComponent,


    ]
    //...
})
export class LayoutModule { }