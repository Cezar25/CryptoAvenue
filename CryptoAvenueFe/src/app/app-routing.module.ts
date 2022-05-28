import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./components/home/home.component";
import {MarketsComponent} from "./components/markets/markets.component";
import {AboutUsComponent} from "./components/about-us/about-us.component";
import {LoginComponent} from "./components/login/login.component";
import {RegisterComponent} from "./components/register/register.component";
import {CoinDetailsComponent} from "./components/coin-details/coin-details.component";
import {UserProfileComponent} from "./components/user-profile/user-profile.component";
import {CreditCardInfoComponent} from "./components/credit-card-info/credit-card-info.component";
import {BankTransferInfoComponent} from "./components/bank-transfer-info/bank-transfer-info.component";
import {BalanceComponent} from "./components/balance/balance.component";


const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch:'full'},
  {path: 'home', component: HomeComponent},
  {path: 'markets', component: MarketsComponent},
  {path: 'about-us', component: AboutUsComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'coin-details/:id', component: CoinDetailsComponent},
  {path: 'user-profile', component: UserProfileComponent},
  {path: 'credit-card-info', component: CreditCardInfoComponent},
  {path: 'bank-transfer-info', component: BankTransferInfoComponent},
  {path: 'balance/:id', component: BalanceComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
