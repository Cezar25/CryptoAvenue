import {Component, OnInit, ViewChild} from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {TradeOfferService} from "../../services/trade-offer.service";
import {TradeOfferInterface} from "../../interfaces/trade-offer-interface";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {MatTableDataSource} from "@angular/material/table";

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})
export class NotificationsComponent implements OnInit {
  userId!: string;
  incomingTradeOffers!: TradeOfferInterface[];

  dataSource!: MatTableDataSource<any>;

  displayedColumns: string[] = ['sender', 'sent_coin', 'received_coin', 'trade_offer_details'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private tradeOfferService: TradeOfferService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.userId = params['userId'];
    })
    console.log(this.userId);

    this.getAllIncomingTradeOffers();

  }

  getAllIncomingTradeOffers() {
    this.tradeOfferService.getAllIncomingTradeOffers(this.userId)
      .subscribe(res => {
        //console.log(res);
        this.incomingTradeOffers = res;
        console.log(this.incomingTradeOffers);
      })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
