import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Things To Do';
  restaurents:any;


  /**
   *
   */
  constructor(private http:HttpClient,private accountService:AccountService) {
   
    
  }
  // on init is added to get life cyle functions this will run after the constructor
  ngOnInit(): void {
   this.getTopRestaurents();
   this.setCurrentUser();
  }

  setCurrentUser(){
   
    var userItem = localStorage.getItem('user') as string;
    var user = JSON.parse(userItem);
    this.accountService.setCurrentUser(user);
  }

  getTopRestaurents(){
    this.http.get('https://localhost:5001/api/thingstodo/TopCategories?category=Restaurent').subscribe(resp => {

      this.restaurents = resp;
    },error =>{
      console.log(error);
    });
  }
}
