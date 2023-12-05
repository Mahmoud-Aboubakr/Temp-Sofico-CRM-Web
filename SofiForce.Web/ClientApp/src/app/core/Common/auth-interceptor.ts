import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private _router:Router) {

        

     }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add authorization header with jwt token if available
        
        let baseUrl=environment.urlAddress;

        var token = localStorage.getItem('sfc_token');
        var lan = localStorage.getItem("lan") !=undefined ? localStorage.getItem("lan") : 'en';

        if (token!=null) {

            request = request.clone({
                url: baseUrl + request.url,
                setHeaders: {
                    Authorization: `Bearer ${token}`,
                    'Cache-Control':'no-cache, no-store, must-revalidate, post-check=0, pre-check=0',
                    'Pragma':'no-cache',
                    'Expires':'0',
                    'lan':lan
                }
            });
        }
        else
        {
            request = request.clone({
                url: baseUrl + request.url,
                setHeaders: {
                    'Cache-Control':'no-cache, no-store, must-revalidate, post-check=0, pre-check=0',
                    'Pragma':'no-cache',
                    'Expires':'0',
                    'lan':lan
                }
            });
            
        }

        return next.handle(request);
        
    }
}