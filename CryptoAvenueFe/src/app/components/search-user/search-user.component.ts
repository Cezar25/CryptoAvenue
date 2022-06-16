import { Component, OnInit } from '@angular/core';
import {Route, Router} from "@angular/router";
import {UserService} from "../../services/user.service";
import {FormBuilder, FormGroup} from "@angular/forms";
import {MatDialog} from "@angular/material/dialog";

@Component({
  selector: 'app-search-user',
  templateUrl: './search-user.component.html',
  styleUrls: ['./search-user.component.css']
})
export class SearchUserComponent implements OnInit {

  searchDetails!: FormGroup;

  foundUserId!: string;

  currentUserEmail!: string;

  constructor(private router: Router,
              private userService: UserService,
              private formBuilder: FormBuilder,
              private dialog: MatDialog) { }

  ngOnInit(): void {

    this.searchDetails = this.formBuilder.group({
      searchedEmail: ['']
    })

    this.userService.getUserById(localStorage.getItem("userId")!)
      .subscribe(res => {
        this.currentUserEmail = res.email;
        console.log("Current user's email logged from search component: "+ this.currentUserEmail);
      })
  }

  search(form: FormGroup) {
    if(form.value.searchedEmail === this.currentUserEmail){
      alert("You cannot search your own account! Please try again!");
      this.searchDetails.reset();
    }
    else if(form.value.searchedEmail !== ''){
      this.userService.getUserByEmail(form.value.searchedEmail)
        .subscribe(res => {
          console.log(res);
          this.foundUserId = res.id;
          console.log(this.foundUserId);

          this.dialog.closeAll();
          this.router.navigate(['user-portfolio', this.foundUserId]);

        }, err => {
          alert("The email you typed in doesn't belong to any user in our database! Please try again!");
          this.searchDetails.reset();
        })

    }
    else {
      alert("The user email field cannot be empty! Please type in an email!");
      this.searchDetails.reset();
    }
  }

}
