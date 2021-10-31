import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  testData:any = {test1:'I am test 1',test2:'I am test 2'}

  ngOnInit(): void {
  }

  cancelTestHome(event:any){

    console.log("Data from Register component ");
    console.log(event);

  }

}
