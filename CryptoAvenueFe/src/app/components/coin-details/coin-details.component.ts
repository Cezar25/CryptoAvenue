import {Component, OnInit, ViewChild} from '@angular/core';
import {CoinGeckoApiService} from "../../services/coin-gecko-api.service";
import {ActivatedRoute} from "@angular/router";
import { ChartConfiguration} from "chart.js";
import { ChartType} from "chart.js";
import { BaseChartDirective} from "ng2-charts";

@Component({
  selector: 'app-coin-details',
  templateUrl: './coin-details.component.html',
  styleUrls: ['./coin-details.component.css']
})
export class CoinDetailsComponent implements OnInit {

  coinData: any;
  coinId: string = "";
  days: number = 1;
  currency: string = "INR";
  public lineChartData: ChartConfiguration['data'] = {
    datasets: [
      {
        data: [],
        label: `Price Trends`,
        backgroundColor: 'rgba(148,159,177,0.2)',
        borderColor: '#009688',
        pointBackgroundColor: '#009688',
        pointBorderColor: '#009688',
        pointHoverBackgroundColor: '#009688',
        pointHoverBorderColor: '#009688',

      }
    ],
    labels: []
  };

  public lineChartOptions: ChartConfiguration['options'] = {
    elements: {
      point: {
        radius: 1
      }
    },

    plugins: {
      legend: { display: true },
    }
  };

  public lineChartType: ChartType = 'line';
  @ViewChild(BaseChartDirective) myLineChart !: BaseChartDirective;

  constructor(private api: CoinGeckoApiService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(val => {
      this.coinId = val['id'];
    })
    this.getCoinData();
  }

  getCoinData() {
    this.api.getCurrencyById(this.coinId)
      .subscribe(res =>{
        this.coinData = res;
        console.log(this.coinData);
      })
  }

}
