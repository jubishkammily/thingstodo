import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

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
  constructor(private http:HttpClient) {
   
    
  }
  // on init is added to get life cyle functions this will run after the constructor
  ngOnInit(): void {
   this.getTopRestaurents();
  }

  getTopRestaurents(){
    this.http.get('http://localhost:5000/api/ThingsToDo?category=Restaurent').subscribe(resp => {

      this.restaurents = resp;
    },error =>{
      console.log(error);
    });
  }
}
