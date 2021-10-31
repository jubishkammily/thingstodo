import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Input() testDataFromHomeParentToChildCommponent:any;  
  
  @Output() testDataToHomeChildToParent = new EventEmitter();

  model:any = {};
  constructor() { }

  ngOnInit(): void {
  }

  register(){
   
  }

  testClick(){
    console.log('Data from Home');
    console.log(this.testDataFromHomeParentToChildCommponent);
  }

cancel(){
  this.testDataToHomeChildToParent.emit("Test Cancel Value from Register");
}

}
