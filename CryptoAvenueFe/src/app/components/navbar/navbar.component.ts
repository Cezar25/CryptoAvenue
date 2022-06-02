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
    localStorage.removeItem("userId");
    this.router.navigate(["/home"]);
    localStorage.removeItem("isOnBalancePage");
  }

  isUserLoggedIn(): boolean {
    /*if(this.isLoggedIn){
      console.log("User is logged in");
    }else{
      console.log("User is not logged in");
    }*/
    return this.isLoggedIn;
  }

  isOnBalancePage(): boolean {
    return !!localStorage.getItem("isOnBalancePage");
  }

  goToHomePage() {
    this.router.navigate(['/home']);
    localStorage.removeItem("isOnBalancePage");
  }

  goToMarketsPage() {
    this.router.navigate(['/markets']);
    localStorage.removeItem("isOnBalancePage");
  }

  goToAboutUsPage() {
    this.router.navigate(['/about-us']);
    localStorage.removeItem("isOnBalancePage");
  }

  goToBalancePage(){
    let userId = localStorage.getItem("userId")!;

    this.router.navigate(['/balance', userId]);
  }

  goToUserSearchPage() {
    this.router.navigate(['/search-for-user']);
  }

  goToDepositPage() {
    let userId = localStorage.getItem("userId")!;

    this.router.navigate(['/deposit', userId]);
  }

  goToWithdrawPage() {
    let userId = localStorage.getItem("userId")!;

    this.router.navigate(['/withdraw', userId]);
  }


}
