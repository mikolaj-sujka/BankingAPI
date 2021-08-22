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
  dateExpires: string;

  constructor(private accountService: AccountService, private memberService: MemberService) { 
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.setCurrentUser();
    this.loadMember();
  }

  loadMember(){
    this.memberService.getMember(this.user.username).subscribe(member => {
      this.member = member;
      this.creditCard = this.member.creditCard;
      this.getDateExpires();
    })
  }

  setCurrentUser(){
    const user: User = JSON.parse(localStorage.getItem('user') || '{}');
    this.accountService.setCurrentUser(user);
  }

  getDateExpires(){
    var date = this.member.creditCard.dateExpires;
    this.dateExpires = new Date(date)
        .toISOString().replace('-', '/').split('T')[0].replace('-', '/');
    this.dateExpires = this.dateExpires.substring(0, this.dateExpires.length - 3);
  }

  // CreditCart properties
  get MemberCreditCardNumber(){
    return (this.member.creditCard && this.member.creditCard.cardNumber) 
      ? this.member.creditCard.cardNumber : null;
  }

  get MemberCreditCardCvc(){
    return (this.member.creditCard && this.member.creditCard.cvc) 
      ? this.member.creditCard.cvc : null;
  }

  get MemberFirstName(){
    return (this.member && this.member.firstName) ? this.member.firstName : null;
  }

  get MemberLastName(){
    return (this.member && this.member.lastName) ? this.member.lastName : null;
  }

}
