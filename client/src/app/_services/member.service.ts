import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';


@Injectable({
  providedIn: 'root'
})
export class MemberService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getMember(username: string){
    return this.http.get<Member>(this.baseUrl + 'users/name/' + username);
  }

  updateMember(member: Member){
    return this.http.put<Member>(this.baseUrl + 'account', member);
  }

  deleteUser(username : string){
    return this.http.delete(this.baseUrl + 'account/delete/' + username);
  }

}
