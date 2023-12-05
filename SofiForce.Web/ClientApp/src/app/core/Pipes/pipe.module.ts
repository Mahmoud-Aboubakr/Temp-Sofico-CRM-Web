import { NgModule } from '@angular/core';
import { HighlightSearchPipe } from './highlight-search/highlight-Search.pipe';
import { TruncatePipe } from './truncate/Truncate.pipe';


@NgModule({
    imports: [
        
    ],
    exports:[
        HighlightSearchPipe,
        TruncatePipe,
    ],
    declarations:[
        HighlightSearchPipe,
        TruncatePipe,
    ]
    //...
})
export class PipeModule { }