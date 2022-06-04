import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params, Route, Router} from "@angular/router";
import {UserService} from "../../services/user.service";
import {WalletService} from "../../services/wallet.service";
import {CoinService} from "../../services/coin.service";
import {TradeOfferService} from "../../services/trade-offer.service";
import {FormBuilder, FormGroup} from "@angular/forms";
import {CoinInterface} from "../../interfaces/coin-interface";
import {CreateTradeOfferModel} from "../../interfaces/create-trade-offer-model";

@Component({
  selector: 'app-send-trade-offer',
  templateUrl: './send-trade-offer.component.html',
  styleUrls: ['./send-trade-offer.component.css']
})
export class SendTradeOfferComponent implements OnInit {

  tradeDetails!: FormGroup;

  senderId!: string;
  recipientId!: string;

  sentCoinId!: string;
  receivedCoinId!: string;

  senderCoins!: CoinInterface[];
  recipientCoins!: CoinInterface[];

  sentTradeDetails!: CreateTradeOfferModel;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private formBuilder: FormBuilder,
              private userService: UserService,
              private walletService: WalletService,
              private coinService: CoinService,
              private tradeOfferService: TradeOfferService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.senderId = params['senderId'];
      this.recipientId = params['recipientId'];
    })

    this.coinService.getAllCoinsByUserId(this.senderId).subscribe(res => {
      this.senderCoins = res;
      console.log(this.senderCoins);
    })

    this.coinService.getAllCoinsByUserId(this.recipientId).subscribe(res => {
      this.recipientCoins = res;
      console.log(this.recipientCoins);
    })

    this.tradeDetails = this.formBuilder.group({
      sentCoinAbbreviation: [''],
      sentCoinAmount: [0],
      receivedCoinAbbreviation: ['']
    })
  }

  sendOffer(form: FormGroup) {
    /*let sentCoinId: string = "";
    let receivedCoinId: string = "";*/

    /*this.coinService.getCoinIdByAbreviation(form.value.sentCoinAbbreviation).subscribe(res => {
      this.sentCoinId = res;
      console.log("Logged sent coin abbreviation from sendOffer method "+ res);
    })

    this.coinService.getCoinIdByAbreviation(form.value.receivedCoinAbbreviation).subscribe(res => {
      this.receivedCoinId = res;
      console.log("Logged received coin abbreviation from sendOffer method "+ res);
    })*/

    this.receivedCoinId = "982552e3-5d73-457c-c8cf-08da2c4f98ed";
    this.sentCoinId = "c9f8230b-4d3d-4e46-c8ce-08da2c4f98ed";

    let sent = form.value.sentCoinAmount;
    console.log(sent);

    const sentOfferDetails = {
      'sentCoinId': this.sentCoinId,
      'receivedCoinId': this.receivedCoinId,
      'senderId': this.senderId,
      'recipientId': this.recipientId,
      'sentCoinAmount': form.value.sentCoinAmount
    }

    this.sentTradeDetails = {
      sentAmount : sentOfferDetails.sentCoinAmount,
      senderID : sentOfferDetails.senderId,
      recipientID : sentOfferDetails.recipientId,
      sentCoinID : sentOfferDetails.sentCoinId,
      receivedCoinID : sentOfferDetails.receivedCoinId
    }

    console.log(this.sentTradeDetails);

    this.tradeOfferService.postTradeOffer(this.sentTradeDetails).subscribe(res => {
      console.log(res);
    })
  }

}
