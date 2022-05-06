import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-markets',
  templateUrl: './markets.component.html',
  styleUrls: ['./markets.component.css']
})
export class MarketsComponent implements OnInit {
  selectedCurrency: string = "EUR";

  constructor() { }

  ngOnInit(): void {
  }

  sendCurrency(event: string){
    console.log(event);
  }

}
