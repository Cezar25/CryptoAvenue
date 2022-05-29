import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {UserService} from "../../services/user.service";

@Component({
  selector: 'app-balance',
  templateUrl: './balance.component.html',
  styleUrls: ['./balance.component.css']
})
export class BalanceComponent implements OnInit {

  userId!: string;

  totalBalanceInEUR!: number;
  totalBalanceInUSD!: number;

  constructor(private router: Router, private route: ActivatedRoute, private userService: UserService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.userId = params['id'];
      console.log("Logged user ID from balance component:");
      console.log(this.userId);
    })

    this.userService.getUserTotalPortofolioValueEUR(this.userId).subscribe(res => {
      console.log(res);
      this.totalBalanceInEUR = res;
    })

    this.userService.getUserTotalPortofolioValueUSD(this.userId).subscribe(res => {
      console.log(res);
      this.totalBalanceInUSD = res;
    })

    localStorage.setItem("isOnBalancePage", "true");
  }

  ngOnDestroy(): void{
    this.route.params.subscribe().unsubscribe();
  }

  /*getTotalBalanceAmountInEUR(): number{
    this.userService.getUserTotalPortofolioValueEUR(this.userId).subscribe(res => {
      console.log(res);
      this.totalBalanceInEUR = res;
    })

    return this.totalBalanceInEUR;
  }

  getTotalBalanceAmountInUSD(): number{
    this.userService.getUserTotalPortofolioValueUSD(this.userId).subscribe(res => {
      console.log(res);
      this.totalBalanceInUSD = res;
    })

    return this.totalBalanceInUSD;
  }*/

}


