import { Component, OnInit } from '@angular/core';
import {FormBuilder} from "@angular/forms";
import {Router} from "@angular/router";
import {WalletService} from "../../services/wallet.service";

@Component({
  selector: 'app-credit-card-info',
  templateUrl: './credit-card-info.component.html',
  styleUrls: ['./credit-card-info.component.css']
})
export class CreditCardInfoComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private router: Router, private walletService: WalletService)
  { }

  ngOnInit(): void {
  }

}
