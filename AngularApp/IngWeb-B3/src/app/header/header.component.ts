import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['../../styles.css']
})
export class HeaderComponent implements OnInit {

  loggedUser = localStorage.getItem("id")
  constructor() { }

  ngOnInit(): void {
    console.log(this.loggedUser)
  }

}
