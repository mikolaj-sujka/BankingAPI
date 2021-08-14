import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MemberService } from 'src/app/_services/member.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-account-page',
  templateUrl: './account-page.component.html',
  styleUrls: ['./account-page.component.css']
})
export class AccountPageComponent implements OnInit {
  username!: string;
  member!: Member;
  user!: User;

  constructor(private accountService: AccountService, private memberService: MemberService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getUser();
    this.loadMember();
  }

  getUser(){
    var jsonValue = localStorage.getItem('user');
    this.user = JSON.parse(jsonValue || '{}');
    this.username = this.user.username;
  }

  loadMember(){
    this.memberService.getMember(this.user.username).subscribe(member => {
      this.member = member;
    })
  }

  deleteUser(){
    this.memberService.deleteUser(this.user.username).subscribe(() =>{
      console.log('Success');
    });
    this.toastr.success('Profile deleted successfully!');
  }

  logout(){
    this.accountService.logout();
  }

}
