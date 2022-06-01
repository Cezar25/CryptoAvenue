import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {map, Observable} from "rxjs";
import {WalletInterface} from "../interfaces/wallet-interface";

@Injectable({
  providedIn: 'root'
})
export class WalletService {

  constructor(private httpClient: HttpClient) { }

  getWalletsByUserId(userId: string): Observable<WalletInterface[]>{
    return this.httpClient.get<WalletInterface[]>("https://localhost:7268/api/Wallets/get-wallets-by-user-id/" + userId)
      .pipe(map((res: WalletInterface[]) => {
        return res;
      }))
  }

  depositToAccount(userId: string, coinId: string, data: number): Observable<WalletInterface>{
    return this.httpClient.post<WalletInterface>("https://localhost:7268/api/Wallets/deposit-to-user-account/" + userId + "/" + coinId, data)
      .pipe(map((res: WalletInterface) => {
        return res;
      }))
  }

  withdrawFromUserAccount(userId: string, coinId: string, data:number): Observable<WalletInterface> {
    return this.httpClient.patch<WalletInterface>("https://localhost:7268/api/Wallets/withdraw-from-user-account/" + userId + "/" + coinId, data)
      .pipe(map((res: WalletInterface) => {
        return res;
      }))
  }

  doesUserHaveCoin(userId: string, coinId: string) {
    return this.httpClient.get<boolean>("https://localhost:7268/api/Wallets/does-the-user-have-any-wallet-containing-searched-coin/" + userId + "/" + coinId)
      .pipe(map((res: boolean) => {
        return res;
      }))
  }
}
