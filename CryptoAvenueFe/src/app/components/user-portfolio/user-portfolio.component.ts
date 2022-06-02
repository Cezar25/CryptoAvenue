import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {FormBuilder} from "@angular/forms";
import {UserService} from "../../services/user.service";
import {WalletService} from "../../services/wallet.service";
import {UserInterface} from "../../interfaces/user-interface";
import {Observable} from "rxjs";

@Component({
  selector: 'app-user-portfolio',
  templateUrl: './user-portfolio.component.html',
  styleUrls: ['./user-portfolio.component.css']
})
export class UserPortfolioComponent implements OnInit {

  user!: UserInterface;
  userId!: string;
  totalBalanceInEur!: number;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private formBuilder: FormBuilder,
              private userService: UserService,
              private walletService: WalletService) { }

  ngOnInit(): void {

    this.route.params.subscribe((params: Params) => {
      this.userId = params['id'];
    })

    this.userService.getUserById(this.userId).subscribe(res => {
      this.user = res;
      console.log(this.user);
    })

    this.userService.getUserTotalPortofolioValueEUR(this.userId)
      .subscribe(res => {
        this.totalBalanceInEur = res;
        console.log(this.totalBalanceInEur);
      })

  }
}
