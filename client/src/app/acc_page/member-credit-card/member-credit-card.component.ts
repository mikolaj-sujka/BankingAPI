import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { CreditCard } from 'src/app/_models/creditCard';
import { Member } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MemberService } from 'src/app/_services/member.service';

@Component({
  selector: 'app-member-credit-card',
  templateUrl: './member-credit-card.component.html',
  styleUrls: ['./member-credit-card.component.css']
})
export class MemberCreditCardComponent implements OnInit {

  member: Member = {} as Member;
  user: User = {} as User;
  creditCard: CreditCard = {} as CreditCard;

  constructor(private accountService: AccountService, private memberService: MemberService) { 
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.loadMember();
  }

  loadMember(){
    this.memberService.getMember(this.user.username).subscribe(member => {
      this.member = member;
      this.creditCard = this.member.creditCard;
    })
  }

}
