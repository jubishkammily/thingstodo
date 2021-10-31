import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],

})
export class NavComponent implements OnInit {

  constructor(public service:AccountService) {
  
    this.service.currentUser$.subscribe(res=>{
      this.model.userName = res.userName;
    })
   }

  model:any={};

  ngOnInit(): void {
   
  }

  login(){
    console.log("username",this.model.userName);
    console.log("password",this.model.password);
    var loginTest = this.service.login(this.model).subscribe(resp => {
      console.log('response');
      console.log(resp);
    },err =>{

      console.log(err);

    });
    
  }

  logOut(){
     this.service.logOut();
  }

}
