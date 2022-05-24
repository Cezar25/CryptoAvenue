import { Component, OnInit } from '@angular/core';
import {UserService} from "../../services/user.service";
import {Router} from "@angular/router";
import {UserInterface} from "../../interfaces/user-interface";
import {FormBuilder, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  user!: UserInterface;

  editProfileForm!: FormGroup;

  constructor(private userService: UserService, private router: Router, private formBuilder: FormBuilder, private httpClient: HttpClient) { }

  ngOnInit(): void {

    this.userService.getUserById(localStorage.getItem("userId")!).subscribe(res => {
      this.user = res;
      console.log(res);
    })

    this.editProfileForm = this.formBuilder.group({
      email: [this.user.email],
      password: [''],
      securityQuestion: [''],
      securityAnswer: [''],
      privateProfile: [false]
    })

  }

  updateUser() {
    this.userService.updateUser(this.editProfileForm.value, this.user.id)
      .subscribe(res => {
        console.log(res);
        this.editProfileForm.reset();
        this.router.navigate(['/home']);
      })


  }

}
