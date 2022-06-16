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

  postTradeOffer(data: TradeOfferInterface): Observable<TradeOfferInterface>{
    return this.httpClient.post<TradeOfferInterface>("https://localhost:7268/CryptoAvenue/TradeOffers", data)
      .pipe(map((res: TradeOfferInterface) => {
        return res;
      }))
  }

  getTradeOfferDetails(tradeOfferId: string): Observable<string>{
    return this.httpClient.get<string>("https://localhost:7268/CryptoAvenue/TradeOffers/get-trade-offer-details/" + tradeOfferId)
      .pipe(map((res: string) => {
        return res;
      }))
  }

  getTradeOfferDetails2(sentCoinId: string, receivedCoinId: string, sentAmount: number): Observable<any>{
    return this.httpClient.get(`https://localhost:7268/CryptoAvenue/TradeOffers/get-trade-offer-details2/${sentCoinId}/${receivedCoinId}/${sentAmount}`,
      { responseType: "text"})
      .pipe(map((res: any) => {
        return res;
      }))
  }

  getTradeOfferById(id: string): Observable<TradeOfferInterface> {
    return this.httpClient.get<TradeOfferInterface>("https://localhost:7268/CryptoAvenue/TradeOffers/get-trade-offer-by-id/" + id)
      .pipe(map((res: TradeOfferInterface) => {
        return res;
      }))
  }

  deleteTradeOffer(tradeOfferId: string): Observable<TradeOfferInterface> {
    return this.httpClient.delete<TradeOfferInterface>("https://localhost:7268/CryptoAvenue/TradeOffers/" + tradeOfferId)
      .pipe(map((res: TradeOfferInterface) => {
        return res;
      }))
  }

  getAllIncomingTradeOffers(userId: string): Observable<TradeOfferInterface[]> {
    return this.httpClient.get<TradeOfferInterface[]>("https://localhost:7268/CryptoAvenue/TradeOffers/get-trade-offers-by-recipient-id/" + userId)
      .pipe(map((res: TradeOfferInterface[]) => {
        return res;
      }))
  }

  acceptTradeOffer(tradeOfferId: string): Observable<TradeOfferInterface> {
    return this.httpClient.delete<TradeOfferInterface>("https://localhost:7268/CryptoAvenue/TradeOffers/apply-trade-offer-to-users/" + tradeOfferId)
      .pipe(map((res: TradeOfferInterface) => {
        return res;
      }))
  }
}
