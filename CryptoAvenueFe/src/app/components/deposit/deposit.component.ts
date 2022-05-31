import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {UserService} from "../../services/user.service";
import {WalletService} from "../../services/wallet.service";

@Component({
  selector: 'app-deposit',
  templateUrl: './deposit.component.html',
  styleUrls: ['./deposit.component.css']
})
export class DepositComponent implements OnInit {

  userId!: string;
  coinId: string = "c9f8230b-4d3d-4e46-c8ce-08da2c4f98ed";
  eur: string = "EUR";
  usd: string = "USD";
  selectedCurrency: string = "EUR";

  depositDetails!: FormGroup;

  constructor(private router: Router, private route: ActivatedRoute, private formBuilder: FormBuilder, private userService: UserService, private walletService: WalletService) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem("userId")!;
    console.log("Logged user ID from deposit component: " + this.userId);

    this.depositDetails = this.formBuilder.group({
      currency: [this.selectedCurrency],
      amount: [0]
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
    const depositData = form.value.amount;

    this.walletService.depositToAccount(this.coinId, this.userId, depositData)
      .subscribe(res => {
        console.log("Response from deposit method: " + res);
        alert("Deposit successful!");
      }, err => {
        alert("Deposit attempt unsuccessful! Please try again!");
      })
  }

  testDeposit(){
    let testCoinId = "c9f8230b-4d3d-4e46-c8ce-08da2c4f98ed";
    let testUserId = "a93aa0e1-0c7e-47dc-c2cf-08da40af59f9";
    this.walletService.depositToAccount(testUserId, testCoinId, 200).subscribe(res => {
      console.log(res);
    })
  }

}
