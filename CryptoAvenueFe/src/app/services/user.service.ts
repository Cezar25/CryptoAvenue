import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {map, Observable} from "rxjs";
import {UserInterface} from "../interfaces/user-interface";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  postUser(data: UserInterface) {
    return this.httpClient.post<UserInterface>("https://localhost:7268/api/Users/", data, {
      withCredentials: true
    })
      .pipe(map((res: UserInterface) => {
        return res;
      }))
  }

  deleteUser(id: string) {
    return this.httpClient.delete<any>("https://localhost:7268/api/Users/" + id)
      .pipe(map((res: any) => {
        return res;
      }))
  }

  updateUser(data: UserInterface, id: string) {
    return this.httpClient.put<any>("https://localhost:7268/api/Users/" + id, data)
      .pipe(map((res: UserInterface) => {
        return res;
      }))
  }

  updateUserEmail( id: string, newEmail: any) {
    return this.httpClient.patch<UserInterface>(`https://localhost:7268/api/Users/${id}/update-user-email/`, newEmail)
      .pipe(map((res: UserInterface) => {
        return res;
      }))
  }

  getUsers() {
    return this.httpClient.get<UserInterface[]>("https://localhost:7268/api/Users/")
      .pipe(map((res: UserInterface[]) => {
        return res;
      }))
  }

  getUserIdByEmail(email: string){
    return this.httpClient.get<UserInterface[]>("https://localhost:7268/api/Users/get-user-id-by-email/" + email)
      .pipe(map((res: any) => {
        return res;
      }))
  }

  getUserById(id: string): Observable<UserInterface>{
    return this.httpClient.get<UserInterface>("https://localhost:7268/api/Users/get-user-by-id/" + id)
      .pipe(map((res: UserInterface) => {
        return res;
      }))
  }

  getUserByEmail(email: string): Observable<UserInterface> {
    return this.httpClient.get<UserInterface>("https://localhost:7268/api/Users/get-user-by-email/" + email)
      .pipe(map((res: UserInterface) => {
        return res;
      }))
  }

  getUserTotalPortofolioValueEUR(id: string) {
    return this.httpClient.get<number>("https://localhost:7268/api/Users/get-user-portofolio-value-eur/" + id)
      .pipe(map((res: any) => {
        return res;
      }))
  }

  getUserTotalPortofolioValueUSD(id: string) {
    return this.httpClient.get<number>("https://localhost:7268/api/Users/get-user-portofolio-value-usd/" + id)
      .pipe(map((res: any) => {
        return res;
      }))
  }

  getUserTotalPortofolioValueBTC(id: string) {
    return this.httpClient.get<number>("https://localhost:7268/api/Users/get-user-portofolio-value-btc/" + id)
      .pipe(map((res: any) => {
        return res;
      }))
  }
}
