import {Component, Inject, OnInit} from '@angular/core';
import {ActivatedRoute, Params, Route, Router} from "@angular/router";
import {WalletService} from "../../services/wallet.service";
import {CoinService} from "../../services/coin.service";
import {TradeOfferService} from "../../services/trade-offer.service";
import {MAT_DIALOG_DATA, MatDialog} from "@angular/material/dialog";

@Component({
  selector: 'app-app-trade-details',
  templateUrl: './app-trade-details.component.html',
  styleUrls: ['./app-trade-details.component.css']
})
export class AppTradeDetailsComponent implements OnInit {

  userId!: string;
  soldCoinWalletId!: string;
  soldCoinId!: string;
  boughtCoinId!: string;
  boughtAmount!: number;

  tradeDetails!: string;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private walletService: WalletService,
              private coinService: CoinService,
              private tradeOfferService: TradeOfferService,
              private dialog: MatDialog,
              @Inject(MAT_DIALOG_DATA) public data: any) {
    this.userId = data.userId;
    this.soldCoinWalletId = data.soldCoinWalletId;
    this.soldCoinId = data.selectedSoldCoinId;
    this.boughtCoinId = data.selectedBoughtCoinId;
    this.boughtAmount = data.boughtAmount;
  }

  ngOnInit(): void {
    /*this.route.params.subscribe((params: Params) => {
      this.userId = params['userId'];
      this.soldCoinWalletId = params['soldCoinWalletId'];
      this.soldCoinId = params['soldCoinId'];
      this.boughtCoinId = params['boughtCoinId'];
      this.boughtAmount = params['boughtAmount'];
    })*/

    this.tradeOfferService.getTradeOfferDetails2(this.soldCoinId, this.boughtCoinId, this.boughtAmount)
      .subscribe(res => {
        this.tradeDetails = res;
        console.log(this.tradeDetails);
      })
  }

  confirm() {
    this.walletService.convertCoinsInUserWallet(this.userId, this.soldCoinWalletId, this.boughtCoinId, this.boughtAmount)
      .subscribe(res => {
        console.log(res);
        alert("Trade successful!");
        this.dialog.closeAll();
        this.router.navigate(['/balance', this.userId]);
      }, err => {
        alert("Trade unsuccessful! Please try again!");
      })
  }

  cancel() {
    this.dialog.closeAll();
    this.router.navigate(['/balance', this.userId]);
  }

}
