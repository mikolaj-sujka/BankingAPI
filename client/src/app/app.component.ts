import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';
import { trigger, transition, group, query, style, animate } from '@angular/animations';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  animations: [
    trigger('routeAnimation', [
      transition('1 => 2', [
        style({height: '!'}),
        query(':enter', style( { transform: 'translateX(100%)'})),
        query(':enter, :leave', style({ position: 'absolute', top: 0, left: 0, right: 0 })),
        group([
            query(':leave', [animate('0.5s cubic-bezier(0.35, 0, 0.25, 1)', style({transform: 'translateX(-100%)'}))]),
            query(':enter', [animate('0.5s cubic-bezier(0.35, 0, 0.25, 1)', style({transform: 'translateX(0)'}))])
        ])
      ]),
      transition('2 => 1', [
        style({height: '!'}),
        query(':enter', style( { transform: 'translateX(-100%)'})),
        query(':enter, :leave', style({ position: 'absolute', top: 0, left: 0, right: 0 })),
        group([
            query(':leave', [animate('0.5s cubic-bezier(0.35, 0, 0.25, 1)', style({transform: 'translateX(100%)'}))]),
            query(':enter', [animate('0.5s cubic-bezier(0.35, 0, 0.25, 1)', style({transform: 'translateX(0)'}))])
        ])
      ]),
      transition('2 => 3', [
        style({height: '!'}),
        query(':enter', style( { transform: 'translateX(100%)'})),
        query(':enter, :leave', style({ position: 'absolute', top: 0, left: 0, right: 0 })),
        group([
            query(':leave', [animate('0.5s cubic-bezier(0.35, 0, 0.25, 1)', style({transform: 'translateX(-100%)'}))]),
            query(':enter', [animate('0.5s cubic-bezier(0.35, 0, 0.25, 1)', style({transform: 'translateX(0)'}))])
        ])
      ]),
      transition('3 => 2', [
        style({height: '!'}),
        query(':enter', style( { transform: 'translateX(-100%)'})),
        query(':enter, :leave', style({ position: 'absolute', top: 0, left: 0, right: 0 })),
        group([
            query(':leave', [animate('0.5s cubic-bezier(0.35, 0, 0.25, 1)', style({transform: 'translateX(100%)'}))]),
            query(':enter', [animate('0.5s cubic-bezier(0.35, 0, 0.25, 1)', style({transform: 'translateX(0)'}))])
        ])
      ])
    ])
  ]
})
export class AppComponent implements OnInit{
  title = 'iFBB BA';
  users: any;

  constructor(private http: HttpClient, private accountService: AccountService) {

  }
  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser(){
    const user:User = JSON.parse(localStorage.getItem('user') as string);
  }

  getDepth(outlet: any){
    return outlet.activatedRouteData['depth'];
  }
}
