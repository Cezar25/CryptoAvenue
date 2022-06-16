import { Component, OnInit } from '@angular/core';
import {Form, FormBuilder, FormGroup} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {UserService} from "../../services/user.service";
import {WalletService} from "../../services/wallet.service";
import {CoinService} from "../../services/coin.service";
import {MatDialog} from "@angular/material/dialog";

@Component({
  selector: 'app-withdraw',
  templateUrl: './withdraw.component.html',
  styleUrls: ['./withdraw.component.css']
})
export class WithdrawComponent implements OnInit {

  eur: string = "EUR";
  usd: string = "USD";
  selectedCurrency: string = "EUR";

  userId!: string;
  coinId!: string;

  eurId!: string;
  usdId!: string;

  withdrawDetails!: FormGroup;

  constructor(private router: Router,
              private route: ActivatedRoute,
              private formBuilder: FormBuilder,
              private userService: UserService,
              private walletService: WalletService,
              private coinService: CoinService,
              private dialog: MatDialog) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem("userId")!;

    if(this.userId) {
      console.log("Logged user ID from withdraw component: " + this.userId);

      this.withdrawDetails = this.formBuilder.group({
        currency: [this.selectedCurrency],
        coinAmount: [0]
      })

      this.coinService.getCoinIdByAbreviation("EUR")
        .subscribe(res => {
          this.eurId = res;
          console.log(this.eurId);
        });

      this.coinService.getCoinIdByAbreviation("USD")
        .subscribe(res => this.usdId = res);

    } else {
      alert("You must be logged in in order to withdraw funds");
      this.router.navigate(['/login']);
    }
  }

  withdraw(form: FormGroup) {
    this.coinService.getCoinIdByAbreviation(form.value.currency)
      .subscribe(res => {
        this.coinId = res;
        console.log(this.coinId);
      })

    const withdrawData = {
      'currency': form.value.currency,
      'userId': this.userId,
      'coinId': this.coinId,
      'amount': form.value.coinAmount
    }

    //this.router.navigate(['/credit-card-info', withdrawData.userId, withdrawData.coinId, withdrawData.amount]);
    //console.log(this.eurId);
    //console.log(this.usdId);


    this.router.navigate(['/credit-card-info', withdrawData.userId, withdrawData.coinId, withdrawData.amount, "withdraw"]);
    this.dialog.closeAll();

    console.log(withdrawData);
  }

  doesUserHaveEur(): boolean {
    this.walletService.doesUserHaveCoin(this.eurId, this.userId)
      .subscribe(res => {
        if(res) return true;
        else {
          alert("You do not own any of the selected currencies! Please go and convert them!");
          return false;
        }
        }
      )
    return false;
  }

  doesUserHaveUsd(): boolean {
    this.walletService.doesUserHaveCoin(this.usdId, this.userId)
      .subscribe(res => {
          if(res) return true;
          else {
            alert("You do not own any of the selected currencies! Please go and convert them!");
            return false;
          }
        }
      )
    return false;
  }


}
