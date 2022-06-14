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
    this.ngOnInit();
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
    this.ngOnInit();
  }

  /*goToMarketsPage() {
    this.router.navigate(['/markets']);
    localStorage.removeItem("isOnBalancePage");
    this.ngOnInit();
  }

  goToAboutUsPage() {
    this.router.navigate(['/about-us']);
    localStorage.removeItem("isOnBalancePage");
    this.ngOnInit();
  }*/

  goToNotificationsPage() {
    this.router.navigate(['/notifications', localStorage.getItem("userId")]);
    this.ngOnInit();
  }

  goToTradePage() {
    this.router.navigate(['/app-trade', localStorage.getItem("userId")]);
    this.ngOnInit();
  }

  goToBalancePage(){
    let userId = localStorage.getItem("userId")!;

    this.router.navigate(['/balance', userId]);
    this.ngOnInit();
  }

  goToUserSearchPage() {
    this.router.navigate(['/search-for-user']);
    this.ngOnInit();
  }

  goToDepositPage() {
    let userId = localStorage.getItem("userId")!;

    this.router.navigate(['/deposit', userId]);
    this.ngOnInit();
  }

  goToWithdrawPage() {
    let userId = localStorage.getItem("userId")!;

    this.router.navigate(['/withdraw', userId]);
    this.ngOnInit();
  }


}
