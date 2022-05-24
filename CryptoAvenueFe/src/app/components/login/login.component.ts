import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {UserService} from "../../services/user.service";
import {HttpClient} from "@angular/common/http";
import {FormBuilder, FormGroup} from "@angular/forms";
import {UserInterface} from "../../interfaces/user-interface";
import {CookieService} from "ngx-cookie-service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;

  users: UserInterface[] = [];
  userId!: string;

  invalidLogin!: boolean;

  constructor(
    private router: Router,
    private usersService: UserService,
    private httpClient: HttpClient,
    private formBuilder: FormBuilder,
    private cookie: CookieService) { }

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

  login2(form: FormGroup) {
    const credentials = {
      'email': form.value.email,

      'password': form.value.password
    }

    this.httpClient.post("https://localhost:7268/api/auth/login/", credentials)
      .subscribe( res => {
        const token = (<any>res).token;

        localStorage.setItem("jwt", token);

        this.usersService.getUserIdByEmail(credentials.email).subscribe(res => {
          this.userId = res;
          console.log(res);
          localStorage.setItem("userId", this.userId);
        })



        this.invalidLogin = false;

        alert("Login succesful!");
        this.router.navigate(["/home"]);
      }, err => {
        alert("Invalid user credentials!");
        this.invalidLogin = true;
      })
  }


}


