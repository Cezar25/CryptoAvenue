import { Component, OnInit } from '@angular/core';
import {FormBuilder} from "@angular/forms";
import {ActivatedRoute, Params, Router} from "@angular/router";
import {WalletService} from "../../services/wallet.service";

@Component({
  selector: 'app-credit-card-info',
  templateUrl: './credit-card-info.component.html',
  styleUrls: ['./credit-card-info.component.css']
})
export class CreditCardInfoComponent implements OnInit {

  userId!: string;
  coinId!: string;
  amount!: number;
  type!: string;

  constructor(private formBuilder: FormBuilder,
              private router: Router,
              private route: ActivatedRoute,
              private walletService: WalletService)
  { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.userId = params['userId'];
      this.coinId = params['coinId'];
      this.amount = params['coinAmount'];
      this.type = params['type'];
    })


  }

  submit() {
    this.amount = Number(this.amount);

    if(this.type === "deposit"){
      this.walletService.depositToAccount(this.userId, this.coinId, this.amount)
        .subscribe(res => {
          console.log(res);
          alert("Deposit successful!");
          this.router.navigate(['/balance', this.userId]);
        }, err => {
          alert("Deposit unsuccessful!");
        })
    }
    else if(this.type === "withdraw"){
      this.walletService.withdrawFromUserAccount(this.userId, this.coinId, this.amount)
        .subscribe(res => {
          console.log(res);
          alert("Withdrawal successful!");
          this.router.navigate(['/balance', this.userId]);
        }, err => {
          alert("Withdrawal unsuccessful!");
        })
    } else {
      alert("No method selected for operation!");
    }


  }

  cancel() {
    this.router.navigate(['/balance', this.userId]);
  }

  switchToBankTransfer() {
    if(this.type === "deposit"){
      this.router.navigate(['/bank-transfer-info', this.userId, this.coinId, this.amount, "deposit"]);
    } else {
      this.router.navigate(['/bank-transfer-info', this.userId, this.coinId, this.amount, "withdraw"]);
    }
  }

}
