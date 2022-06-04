import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {TradeOfferInterface} from "../interfaces/trade-offer-interface";
import {map, Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class TradeOfferService {

  constructor(private httpClient: HttpClient) { }

  postTradeOffer(data: TradeOfferInterface): Observable<TradeOfferInterface>{
    return this.httpClient.post<TradeOfferInterface>("\"https://localhost:7268/CryptoAvenue/TradeOffers", data)
      .pipe(map((res: TradeOfferInterface) => {
        return res;
      }))
  }
}
