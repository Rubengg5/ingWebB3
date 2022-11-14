import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-pablo',
  templateUrl: './test-pablo.component.html',
  styleUrls: ['./test-pablo.component.css']
})
export class TestPabloComponent implements OnInit {
  exampleString: string;
  exampleArray: string[];

  constructor() {
    this.exampleArray = [];
    this.exampleString = "Hola!! exampleString";
   }

  ngOnInit(): void {
  }

}
