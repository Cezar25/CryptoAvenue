import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {Form, FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {UserService} from "../../services/user.service";
import {WalletService} from "../../services/wallet.service";
import {CoinService} from "../../services/coin.service";
import {MatDialog} from "@angular/material/dialog";

@Component({
  selector: 'app-deposit',
  templateUrl: './deposit.component.html',
  styleUrls: ['./deposit.component.css']
})
export class DepositComponent implements OnInit {

  userId!: string;
  //coinId: string = "c9f8230b-4d3d-4e46-c8ce-08da2c4f98ed";
  coinId!: string;
  eur: string = "EUR";
  usd: string = "USD";
  selectedCurrency: string = "EUR";
  selectedAmount!: number;

  depositDetails!: FormGroup;

  constructor(private router: Router,
              private route: ActivatedRoute,
              private formBuilder: FormBuilder,
              private userService: UserService,
              private walletService: WalletService,
              private coinService: CoinService,
              private dialog: MatDialog) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem("userId")!;
    if(this.userId){
      console.log("Logged user ID from deposit component: " + this.userId);

      this.depositDetails = this.formBuilder.group({
        currency: [this.selectedCurrency],
        coinAmount: [0]
      })
    } else {
      alert("You must be logged in in order to deposit funds");
      this.router.navigate(['/login']);
    }

  }

  deposit(form: FormGroup){
    //const random

    this.coinService.getCoinIdByAbreviation(form.value.currency)
      .subscribe(res => {
        this.coinId = res;
        console.log(this.coinId);
      })

    //console.log(this.coinId);
    //console.log(form.value.coinAmount);

    const depositData = {
      'currency': form.value.currency,
      'userId': this.userId,
      'coinId': this.coinId,
      'amount': form.value.coinAmount
    }

    //depositData.amount = depositData.amount.parseFloat;
    //depositData.amount = Number(depositData.amount);
    //.log("Float deposit amount: " + depositData.amount);

    /*this.walletService.depositToAccount(depositData.userId, depositData.coinId, depositData.amount)
      .subscribe(res => {
        console.log(res);
      })*/


    this.router.navigate(['/credit-card-info', depositData.userId, depositData.coinId, depositData.amount, "deposit"]);
    this.dialog.closeAll();

    console.log(depositData);
  }

  /*testDeposit(){
    let testCoinId = "c9f8230b-4d3d-4e46-c8ce-08da2c4f98ed";
    let testUserId = "a93aa0e1-0c7e-47dc-c2cf-08da40af59f9";
    this.walletService.depositToAccount(testUserId, testCoinId, 200).subscribe(res => {
      console.log(res);
    })
  }*/

}
