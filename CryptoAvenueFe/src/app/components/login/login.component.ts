import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {UserService} from "../../services/user.service";
import {HttpClient} from "@angular/common/http";
import {FormBuilder, FormGroup} from "@angular/forms";
import {UserInterface} from "../../interfaces/user-interface";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;

  users: UserInterface[] = [];

  constructor(private router: Router, private usersService: UserService, private httpClient: HttpClient, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.usersService.getUsers().subscribe(res => {
      this.users = res;
      console.log(res);
    })

    this.loginForm = this.formBuilder.group({
      email: [''],
      password: [''],
      securityQuestion: [''],
      securityAnswer: ['']
    })
  }

  login() {
    //const user = this.users.find(x => x.email === this.loginForm.value.email && x.password === this.loginForm.value.password);

   /* if(user && this.loginForm.valid){
      alert("Login successful!");
      this.loginForm.reset();
      this.router.navigate(['/home']);
    } else {
      alert("Email or password is wrong! Please try again!");
    }*/

    this.usersService.getUsers().subscribe(res => {
      //console.log("triggered");

      const user = res.find((a: UserInterface) => {
        return a.email === this.loginForm.value.email && a.password === this.loginForm.value.password;
      });

      if(user){
        alert("Login successful!");
        console.log(user);
        this.loginForm.reset();
        this.router.navigate(['/home']);
      }else {
        alert("User not found!");
      }
    }, err => {
      alert("Something went wrong!");
    })

  }


}


