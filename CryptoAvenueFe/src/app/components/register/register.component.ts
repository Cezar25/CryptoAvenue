import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {UserService} from "../../services/user.service";
import {UserInterface} from "../../interfaces/user-interface";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm!: FormGroup;

  users: UserInterface[] = [];

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient, private router: Router, private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(res => {
      this.users = res;
      console.log(res);
    })

    this.registerForm = this.formBuilder.group({
      email: [''],
      password: [''],
      age: [0],
      securityQuestion: [''],
      securityAnswer: [''],
      privateProfile: [false]
    })
  }

  register() {
    this.userService.postUser(this.registerForm.value)
      .subscribe(res => {
        console.log(res);
        this.registerForm.reset();
        this.router.navigate(['/home']);
      })


  }


}
