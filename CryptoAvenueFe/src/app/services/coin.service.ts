import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {map, Observable} from "rxjs";
import {CoinInterface} from "../interfaces/coin-interface";

@Injectable({
  providedIn: 'root'
})
export class CoinService {

  constructor(private httpClient: HttpClient) { }

  getAllCoins(): Observable<CoinInterface[]> {
    return this.httpClient.get<CoinInterface[]>("https://localhost:7268/api/Coins/")
      .pipe(map((res: CoinInterface[]) => {
        return res;
      }))
  }

  getCoinIdByAbreviation(abbreviation: string): Observable<string>{
    return this.httpClient.get<string>("https://localhost:7268/api/Coins/get-coin-id-by-abrevation/" + abbreviation)
      .pipe(map((res: string) => {
        return res;
      }))
  }

  getAllCoinsByUserId(userId: string): Observable<CoinInterface[]> {
    return this.httpClient.get<CoinInterface[]>("https://localhost:7268/api/Coins/get-all-coins-by-user-id/" + userId)
      .pipe(map((res: CoinInterface[]) => {
        return res;
      }))
  }
}
