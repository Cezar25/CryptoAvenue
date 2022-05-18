import { Component, OnInit } from '@angular/core';
import {User} from "../../models/user.model";
import {Observable} from "rxjs";
import {UserInterface} from "../../interfaces/user-interface";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {

  users : UserInterface[] = [
    /*{ Email: "email", Password: "Password1", Age: 12, SecurityQuestion: "q1", SecurityAnswer: "a1",
    Id: "12312312", PrivateProfile: false}*/
  ];

  constructor() { }

  ngOnInit(): void {

  }

}
