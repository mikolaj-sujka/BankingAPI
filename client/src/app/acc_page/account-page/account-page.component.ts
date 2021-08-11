import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-account-page',
  templateUrl: './account-page.component.html',
  styleUrls: ['./account-page.component.css']
})
export class AccountPageComponent implements OnInit {
  user!: User;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.getUserName();
  }

  getUserName(){
    this.accountService.currentUser$.subscribe(response => {
      this.user = response;
    })
  }

}
