import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {map} from "rxjs";
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

  updateUser(data: any, id: string) {
    return this.httpClient.patch<any>("" + id, data)
      .pipe(map((res: any) => {
        return res;
      }))
  }

  getUsers() {
    return this.httpClient.get<UserInterface[]>("https://localhost:7268/api/Users/")
      .pipe(map((res: UserInterface[]) => {
        return res;
      }))
  }
}
