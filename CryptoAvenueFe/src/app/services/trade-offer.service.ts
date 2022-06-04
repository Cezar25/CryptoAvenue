import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {TradeOfferInterface} from "../interfaces/trade-offer-interface";
import {map, Observable} from "rxjs";
import {CreateTradeOfferModel} from "../interfaces/create-trade-offer-model";

@Injectable({
  providedIn: 'root'
})
export class TradeOfferService {

  constructor(private httpClient: HttpClient) { }

  postTradeOffer(data: CreateTradeOfferModel): Observable<CreateTradeOfferModel>{
    return this.httpClient.post<CreateTradeOfferModel>("https://localhost:7268/CryptoAvenue/TradeOffers", data)
      .pipe(map((res: CreateTradeOfferModel) => {
        return res;
      }))
  }
}
