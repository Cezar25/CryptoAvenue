import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {JwtHelperService} from "@auth0/angular-jwt";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  isLoggedIn!: boolean;

  constructor(private router: Router, private jwtHelper: JwtHelperService) { }

  ngOnInit(): void {
    const token = localStorage.getItem("jwt");
    this.isLoggedIn = !!(token && !this.jwtHelper.isTokenExpired(token));
  }

  logOut() {
    localStorage.removeItem("jwt");
    this.router.navigate(["/home"]);
  }

  isUserLoggedIn(): boolean {
    console.log("isLoggedIn method triggered.");
    return this.isLoggedIn;
  }

  goToHomePage() {
    this.router.navigate(['home']);
  }

}
