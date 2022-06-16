import {Component, Inject, OnInit} from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {FormBuilder} from "@angular/forms";
import {UserService} from "../../services/user.service";
import {WalletService} from "../../services/wallet.service";
import {CoinService} from "../../services/coin.service";
import {TradeOfferService} from "../../services/trade-offer.service";
import {TradeOfferInterface} from "../../interfaces/trade-offer-interface";
import {MAT_DIALOG_DATA, MatDialog} from "@angular/material/dialog";

@Component({
  selector: 'app-trade-offer-details',
  templateUrl: './trade-offer-details.component.html',
  styleUrls: ['./trade-offer-details.component.css']
})
export class TradeOfferDetailsComponent implements OnInit {

  senderId!: string;
  recipientId!: string;
  sentCoinId!: string;
  receivedCoinId!: string;
  sentAmount!: number;

  tradeOfferDetails!: string;
  splitDetails!: string[];

  constructor(private route: ActivatedRoute,
              private router: Router,
              private tradeOfferService: TradeOfferService,
              @Inject(MAT_DIALOG_DATA) public data: any,
              private dialog: MatDialog) {
    this.senderId = data.senderId;
    this.recipientId = data.recipientId;
    this.sentCoinId = data.sentCoinId;
    this.receivedCoinId = data.receivedCoinId;
    this.sentAmount = data.sentCoinAmount;
  }

  ngOnInit(): void {

    this.tradeOfferService.getTradeOfferDetails2(this.sentCoinId, this.receivedCoinId, this.sentAmount)
      .subscribe(res => {
        //console.log(res);
        this.tradeOfferDetails = res;
        console.log(this.tradeOfferDetails);
      })

  }

  createTradeOffer() {
    const sentTradeOfferDetails: TradeOfferInterface = {
      id: "",
      sentAmount: this.sentAmount,
      receivedAmount: 0,
      senderID: this.senderId,
      recipientID: this.recipientId,
      sentCoinID: this.sentCoinId,
      receivedCoinID: this.receivedCoinId
    }

    this.tradeOfferService.postTradeOffer(sentTradeOfferDetails)
      .subscribe(res => {
        console.log(res);
        alert("Offer sent successfully! You are being redirected to the Balance page!");
        this.dialog.closeAll();
        this.router.navigate(['/balance', this.senderId]);
      }, err => {
        alert("Offer sending unsuccessful! Please try again!");
      })

    //this.tradeOfferService.getTradeOfferDetails()
  }

  cancel() {
    this.dialog.closeAll();
    this.router.navigate(['/balance', this.senderId]);
  }

  isAccepting(): boolean {
    return !!localStorage.getItem("isOnAccept");
  }

  deny() {
    this.tradeOfferService.deleteTradeOffer(localStorage.getItem("viewedOfferId")!)
      .subscribe(res => {
        console.log(res);
      })
    localStorage.removeItem("viewedOfferId");
    localStorage.removeItem("isOnAccept");
    this.dialog.closeAll();
  }

  accept() {
    this.tradeOfferService.acceptTradeOffer(localStorage.getItem("viewedOfferId")!)
      .subscribe(res => {
        console.log("Deleted trade offer:");
        console.log(res);
        alert("Trade offer accepted successfully!");
        this.dialog.closeAll();
      }, err => {
        alert("Trade offer cannot be accepted!");
        this.dialog.closeAll();
      })
    localStorage.removeItem("viewedOfferId");
    localStorage.removeItem("isOnAccept");
  }

}
