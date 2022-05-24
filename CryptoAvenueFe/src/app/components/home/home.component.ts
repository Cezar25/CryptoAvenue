import { Component, OnInit } from '@angular/core';
import {User} from "../../models/user.model";
import {Observable} from "rxjs";
import {UserInterface} from "../../interfaces/user-interface";
import {UserService} from "../../services/user.service";
import {tokenGetter} from "../../app.module";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {

  users : UserInterface[] = [];

  user!: UserInterface;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(res => {
      this.users = res;
      console.log(res);
    })

    //this.userId = localStorage.getItem("userId")!;

    this.userService.getUserById(localStorage.getItem("userId")!).subscribe(res => {
      console.log(res);
    })
  }

}
