import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Router } from '@angular/router';
import { UserService } from '../services/User.Service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private router:Router,private _auth:UserService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {
            
            if (err.status === 401) {
                localStorage.clear();
                this._auth.onAuthorizationChange.next({show:false,data:null});
                this.router.navigateByUrl("/auth/login");
            }

            //const error = err.error.message || err.statusText;
            return throwError(err);
        }))
    }
}