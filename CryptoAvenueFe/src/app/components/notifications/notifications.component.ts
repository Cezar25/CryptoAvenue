import {Component, OnInit, ViewChild} from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {TradeOfferService} from "../../services/trade-offer.service";
import {TradeOfferInterface} from "../../interfaces/trade-offer-interface";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {MatTable, MatTableDataSource} from "@angular/material/table";
import {BalanceTableItem} from "../balance-table/balance-table-datasource";
import {MatDialog} from "@angular/material/dialog";
import {TradeOfferDetailsComponent} from "../trade-offer-details/trade-offer-details.component";

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})
export class NotificationsComponent implements OnInit {
  userId!: string;
  incomingTradeOffers!: TradeOfferInterface[];

  displayedColumns: string[] = ['senderId', 'sentCoinId', 'sentAmount', 'receivedCoinId', 'receivedAmount'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<BalanceTableItem>;
  dataSource!: MatTableDataSource<any>;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private dialog: MatDialog,
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
        this.dataSource = new MatTableDataSource(res);
        console.log(this.dataSource);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  goToTradeOfferDetails(tradeOfferId: string) {
    let offer: TradeOfferInterface;
    this.tradeOfferService.getTradeOfferById(tradeOfferId)
      .subscribe(res => {
        offer = res;
        console.log("Selected trade offer:");
        console.log(offer);

        this.dialog.open(TradeOfferDetailsComponent, {
          width: 'auto',
          data: {
            senderId: offer.senderID,
            recipientId: offer.recipientID,
            sentCoinId: offer.sentCoinID,
            receivedCoinId: offer.receivedCoinID,
            sentCoinAmount: offer.sentAmount
          }
        })

        localStorage.setItem("isOnAccept", "yes");
        localStorage.setItem("viewedOfferId", tradeOfferId);
      })
  }

}
