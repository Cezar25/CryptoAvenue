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
import {DepositComponent} from "./components/deposit/deposit.component";
import {WithdrawComponent} from "./components/withdraw/withdraw.component";
import {SearchUserComponent} from "./components/search-user/search-user.component";
import {UserPortfolioComponent} from "./components/user-portfolio/user-portfolio.component";
import {UserTradeOffersComponent} from "./components/user-trade-offers/user-trade-offers.component";
import {TradeOfferDetailsComponent} from "./components/trade-offer-details/trade-offer-details.component";
import {SendTradeOfferComponent} from "./components/send-trade-offer/send-trade-offer.component";


const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch:'full'},
  {path: 'home', component: HomeComponent},
  {path: 'markets', component: MarketsComponent},
  {path: 'about-us', component: AboutUsComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'coin-details/:id', component: CoinDetailsComponent},
  {path: 'user-profile', component: UserProfileComponent},
  {path: 'credit-card-info/:userId/:coinId/:coinAmount/:type', component: CreditCardInfoComponent},
  {path: 'bank-transfer-info/:userId/:coinId/:coinAmount/:type', component: BankTransferInfoComponent},
  {path: 'balance/:id', component: BalanceComponent},
  {path: 'deposit/:id', component: DepositComponent},
  {path: 'withdraw/:id', component: WithdrawComponent},
  {path: 'search-for-user', component: SearchUserComponent},
  {path: 'user-portfolio/:id', component: UserPortfolioComponent},
  {path: 'user-trade-offers/:senderId/:recipientId', component: UserTradeOffersComponent},
  {path: 'trade-offer-details/:tradeOfferId', component: TradeOfferDetailsComponent},
  {path: 'send-trade-offer/:senderId/:recipientId', component: SendTradeOfferComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
