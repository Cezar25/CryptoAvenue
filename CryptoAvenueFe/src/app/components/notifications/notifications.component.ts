import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {TradeOfferService} from "../../services/trade-offer.service";
import {TradeOfferInterface} from "../../interfaces/trade-offer-interface";

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})
export class NotificationsComponent implements OnInit {
  userId!: string;
  incomingTradeOffers!: TradeOfferInterface[];

  constructor(private route: ActivatedRoute,
              private router: Router,
              private tradeOfferService: TradeOfferService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.userId = params['userId'];
    })

    this.tradeOfferService.getAllIncomingTradeOffers(this.userId)
      .subscribe(res => {
        console.log(res);
        this.incomingTradeOffers = res;
      })
    console.log(this.incomingTradeOffers);
  }

}
