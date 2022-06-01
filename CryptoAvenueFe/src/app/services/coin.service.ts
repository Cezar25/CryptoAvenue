import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {map, Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class CoinService {

  constructor(private httpClient: HttpClient) { }

  getCoinIdByAbreviation(abbreviation: string): Observable<string>{
    return this.httpClient.get<string>("https://localhost:7268/api/Coins/get-coin-id-by-abrevation/" + abbreviation)
      .pipe(map((res: string) => {
        return res;
      }))
  }
}
