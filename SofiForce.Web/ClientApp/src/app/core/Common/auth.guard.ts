import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { UserModel } from '../Models/DtoModels/UserModel';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(
        private router: Router
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        console.log(route.data.code);
        let current: UserModel = JSON.parse(localStorage.getItem('user'))
        
        if(current==null || current.userFeatures==undefined || current.userFeatures==null){
            return false;
          }

        var exist = current.userFeatures.find(a => a.featureCode === route.data.code);
        if (exist) {
            return true;
        }
        else {
            this.router.navigateByUrl("/auth/error-401");
        }

    }
}