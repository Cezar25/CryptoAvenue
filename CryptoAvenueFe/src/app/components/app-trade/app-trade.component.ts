import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {UserService} from "../../services/user.service";
import {WalletService} from "../../services/wallet.service";
import {TradeOfferService} from "../../services/trade-offer.service";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {WalletInterface} from "../../interfaces/wallet-interface";
import {CoinService} from "../../services/coin.service";
import {CoinInterface} from "../../interfaces/coin-interface";

@Component({
  selector: 'app-app-trade',
  templateUrl: './app-trade.component.html',
  styleUrls: ['./app-trade.component.css']
})
export class AppTradeComponent implements OnInit {

  userId!: string;
  ownedWallets!: WalletInterface[];
  ownedCoins!: CoinInterface[];
  allCoins!: CoinInterface[];
  tradeForm!: FormGroup;
  selectedBoughtCoinAbbreviation!: string;
  selectedSoldCoinAbbreviation!: string;

  selectedBoughtCoinId!: string;
  soldCoinWallet!: WalletInterface;
  selectedSoldCoinId!: string;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private userService: UserService,
              private walletService: WalletService,
              private tradeOfferService: TradeOfferService,
              private coinService: CoinService,
              private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.userId = params['userId'];
    })

    this.initForm();
    this.getAllData();
  }

  getAllData() {
    this.walletService.getWalletsByUserId(this.userId)
      .subscribe(res => {
        this.ownedWallets = res;
        console.log(this.ownedWallets);
      })

    this.coinService.getAllCoinsByUserId(this.userId)
      .subscribe(res => {
        this.ownedCoins = res;
        console.log(this.ownedCoins);
      })

    this.coinService.getAllCoins().subscribe(res => {
      this.allCoins = res;
      console.log(this.allCoins);
    })
  }

  initForm() {
    this.tradeForm = this.formBuilder.group({
      boughtCoin: [''],
      sentCoin: [''],
      boughtAmount: new FormControl(0, [
        Validators.pattern("^(?=.)([+-]?([0-9]*)(\\.([0-9]+))?)$"),
        Validators.min(0.01)
      ]),
    })
  }

  goToTradeDetails(form: FormGroup) {

    this.getCoinIds(form);

    this.walletService.getWalletByCoinAndUserId(this.selectedSoldCoinId, this.userId)
      .subscribe(res => {
        this.soldCoinWallet = res;
        console.log(this.soldCoinWallet);
      })

    /*this.walletService.convertCoinsInUserWallet(this.userId, this.soldCoinWallet.id, this.selectedBoughtCoinId, form.value.boughtAmount)
      .subscribe(res => {
        console.log(res);
        this.router.navigate(['/balance', this.userId]);
      })*/

    this.router.navigate(['/app-trade-details',
    this.userId,
    this.soldCoinWallet.id,
    this.selectedSoldCoinId,
    this.selectedBoughtCoinId,
    form.value.boughtAmount])
  }

  getCoinIds(form: FormGroup) {
    this.coinService.getCoinIdByAbreviation(form.value.boughtCoin)
      .subscribe(res => {
        this.selectedBoughtCoinId = res;
        console.log(this.selectedBoughtCoinId);
      })

    this.coinService.getCoinIdByAbreviation(form.value.sentCoin)
      .subscribe(res => {
        this.selectedSoldCoinId = res;
        console.log(this.selectedSoldCoinId);
      })
  }

}
