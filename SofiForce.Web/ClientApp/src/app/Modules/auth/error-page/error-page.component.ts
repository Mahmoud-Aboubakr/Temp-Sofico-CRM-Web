import { Component, HostListener, OnInit } from '@angular/core';
import { CarouselConfig } from 'ngx-bootstrap/carousel';
import { UserService } from 'src/app/core/services/User.Service';
import {Location} from '@angular/common';
import { UserModel } from 'src/app/core/Models/DtoModels/UserModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-error-page',
  templateUrl: './error-page.component.html',
  styleUrls: ['./error-page.component.scss'],
  providers: [
    { provide: CarouselConfig, useValue: { interval: 3000, noPause: true, showIndicators: false } }
  ]
})
export class ErrorPageComponent implements OnInit {

  current: UserModel;

  
  constructor(private _UserService: UserService,private _router: Router,) {
    this.current = JSON.parse(localStorage.getItem('user'))
   }

  ngOnInit(): void {
    this._UserService.onAuthorizationChange.next({show:false,data:null});
  }


  getToHome(){
    if(this.current.defualtUrl){
      this._UserService.onAuthorizationChange.next({show:true,data:this.current});
      this._router.navigateByUrl("/auth/Login");
    }
  }
}
