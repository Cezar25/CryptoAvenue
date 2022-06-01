import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {Form, FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {UserService} from "../../services/user.service";
import {WalletService} from "../../services/wallet.service";
import {CoinService} from "../../services/coin.service";

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
  testForm!: FormGroup;

  constructor(private router: Router,
              private route: ActivatedRoute,
              private formBuilder: FormBuilder,
              private userService: UserService,
              private walletService: WalletService,
              private coinService: CoinService) { }

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

    this.testForm = this.formBuilder.group({
      coinAmount: [0]
    })

  }

  changeToEur(){
    this.selectedCurrency = "EUR";
    console.log("Changed selected currency to EUR");
  }

  changeToUsd(){
    this.selectedCurrency = "USD";
    console.log("Changed selected currency to USD");
  }

  deposit(form: FormGroup){
    //let depositData: number = 55;
    const depositData: number = form.value.coinAmount.parseFloat;
    console.log("Logged from coin amount: " + form.value.coinAmount);
    console.log("Logged amount from deposit method:");
    console.log(depositData);
    //let depositData: number = 55;

    this.walletService.depositToAccount(this.userId, this.coinId, depositData)
      .subscribe(res => {
        console.log("Response from deposit method: " + res);
        alert("Deposit successful!");
      }, err => {
        alert("Deposit attempt unsuccessful! Please try again!");
      })
  }

  deposit2(form: FormGroup){
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

    this.walletService.depositToAccount(depositData.userId, depositData.coinId, depositData.amount)
      .subscribe(res => {
        console.log(res);
      })

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
