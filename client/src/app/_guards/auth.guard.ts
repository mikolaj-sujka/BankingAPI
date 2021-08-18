import { Injectable } from '@angular/core';
import { CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, of } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private accountService: AccountService, private toastr: ToastrService,
    private router: Router){}

  canActivate(): Observable<boolean>{
    console.log(this.accountService.currentUser$);
    return this.accountService.currentUser$.pipe(
      map(user => {
        const userLogged = !!user;
        if(userLogged){
          console.log(true);
          return true;
        } 
        else{
          this.toastr.error("No entry");
          this.router.navigate(['account/login']);
          console.log(false);
          return false;
        }
      })
    )
  }

}
