import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatToolbarModule} from "@angular/material/toolbar";
import { MatButtonModule} from "@angular/material/button";
import { MatIconModule} from "@angular/material/icon";
import { MatSelectModule} from "@angular/material/select";
import { MatFormFieldModule} from "@angular/material/form-field";
import { MatInputModule} from "@angular/material/input";
import { HttpClientModule} from "@angular/common/http";
import { MatTableModule} from "@angular/material/table";
import { MatPaginatorModule} from "@angular/material/paginator";
import {MatSortModule} from "@angular/material/sort";
import {MatGridListModule} from "@angular/material/grid-list";
import { MatCardModule} from "@angular/material/card";
import { NgChartsModule} from "ng2-charts";


import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HomeComponent } from './components/home/home.component';
import { MarketsComponent } from './components/markets/markets.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { CoinTableComponent } from './components/coin-table/coin-table.component';
import { CoinDetailsComponent } from './components/coin-details/coin-details.component';
import {MatTabsModule} from "@angular/material/tabs";
import {MatCheckboxModule} from "@angular/material/checkbox";
import {FlexLayoutModule} from "@angular/flex-layout";
import {MatSidenavModule} from "@angular/material/sidenav";
import {LoggerService} from "./services/logger.service";
import {CoinGeckoApiService} from "./services/coin-gecko-api.service";
import {UserService} from "./services/user.service";
import {CookieService} from "ngx-cookie-service";
import {JwtModule} from "@auth0/angular-jwt";
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import {MatSlideToggleModule} from "@angular/material/slide-toggle";
import { CreditCardInfoComponent } from './components/credit-card-info/credit-card-info.component';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    MarketsComponent,
    LoginComponent,
    RegisterComponent,
    AboutUsComponent,
    CoinTableComponent,
    CoinDetailsComponent,
    UserProfileComponent,
    CreditCardInfoComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FormsModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatSelectModule,
    MatFormFieldModule,
    MatInputModule,
    HttpClientModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatGridListModule,
    MatCardModule,
    MatTabsModule,
    MatCheckboxModule,
    FlexLayoutModule,
    MatSidenavModule,
    NgChartsModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["http://localhost:4200/"],
        disallowedRoutes: []
      }
    }),
    MatSlideToggleModule
  ],
  providers: [LoggerService, CoinGeckoApiService, UserService, CookieService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
