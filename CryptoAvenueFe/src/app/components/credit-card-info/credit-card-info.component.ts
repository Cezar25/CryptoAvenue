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
  depositedAmount!: number;

  constructor(private formBuilder: FormBuilder,
              private router: Router,
              private route: ActivatedRoute,
              private walletService: WalletService)
  { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.userId = params['userId'];
      this.coinId = params['coinId'];
      this.depositedAmount = params['coinAmount'];
    })


  }

  submit() {
    this.depositedAmount = Number(this.depositedAmount);
    this.walletService.depositToAccount(this.userId, this.coinId, this.depositedAmount)
      .subscribe(res => {
        console.log(res);
        alert("Deposit successful!");
        this.router.navigate(['/balance', this.userId]);
      }, err => {
        alert("Deposit unsuccessful!");
      })

  }

  cancel() {
    this.router.navigate(['/balance', this.userId]);
  }

  switchToBankTransfer() {
    this.router.navigate(['/bank-transfer-info', this.userId, this.coinId, this.depositedAmount]);
  }

}
