import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {FormBuilder} from "@angular/forms";
import {UserService} from "../../services/user.service";
import {WalletService} from "../../services/wallet.service";
import {CoinService} from "../../services/coin.service";
import {TradeOfferService} from "../../services/trade-offer.service";
import {TradeOfferInterface} from "../../interfaces/trade-offer-interface";

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
              private tradeOfferService: TradeOfferService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.senderId = params['senderId'];
      this.recipientId = params['recipientId'];
      this.sentCoinId = params['sentCoinId'];
      this.receivedCoinId = params['receivedCoinId'];
      this.sentAmount = params['sentAmount'];
    })

    this.tradeOfferService.getTradeOfferDetails2(this.sentCoinId, this.receivedCoinId, this.sentAmount)
      .subscribe(res => {
        //console.log(res);
        this.tradeOfferDetails = res;
        console.log(this.tradeOfferDetails);
      })

    /*this.splitDetails = this.tradeOfferDetails.split("\n");
    console.log(this.splitDetails[0]);
    console.log(this.splitDetails[1]);*/

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
        this.router.navigate(['/balance', this.senderId]);
      }, err => {
        alert("Offer sending unsuccessful! Please try again!");
      })

    //this.tradeOfferService.getTradeOfferDetails()
  }

  cancel() {
    this.router.navigate(['/balance', this.senderId]);
  }

}
