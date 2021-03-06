import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators'
import { User } from '../_models/user'



@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = 'https://localhost:5001/api/thingstodo'
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();
  constructor(private http:HttpClient) { }

  login(model:any){
   
    return this.http.post(this.baseUrl+'/Login',model).pipe(

      map((response)=>{
        const user = response as User;
        if(user){
          localStorage.setItem('user',JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
      
  }

  setCurrentUser(user:User){
    this.currentUserSource.next(user);
  }


  logOut(){
    localStorage.removeItem('user');
    this.currentUserSource.next(undefined);
    // this.currentUser$ = this.currentUserSource.asObservable();
  }
}
