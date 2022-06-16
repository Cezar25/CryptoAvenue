import {Component, OnInit, ViewChild} from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {UserService} from "../../services/user.service";
import {WalletService} from "../../services/wallet.service";
import {UserInterface} from "../../interfaces/user-interface";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {MatTable, MatTableDataSource} from "@angular/material/table";
import {BalanceTableDataSource, BalanceTableItem} from "../balance-table/balance-table-datasource";
import {WalletInterface} from "../../interfaces/wallet-interface";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-balance',
  templateUrl: './balance.component.html',
  styleUrls: ['./balance.component.css']
})
export class BalanceComponent implements OnInit {

  userId!: string;
  user!: UserInterface;

  totalBalanceInEUR!: number;
  totalBalanceInUSD!: number;

  valueInEurSubscription!: Subscription;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<BalanceTableItem>;
  dataSource!: MatTableDataSource<any>;

  displayedColumns: string[] = ['id', 'coinAmount'];

  constructor(private router: Router, private route: ActivatedRoute, private userService: UserService, private walletService: WalletService) { }

  ngOnInit(): void {

    this.route.params.subscribe((params: Params) => {
      this.userId = params['id'];
      console.log("Logged user ID from balance component:");
      console.log(this.userId);
    })

    this.userService.getUserById(this.userId).subscribe(res => {
      this.user = res;
      console.log(this.user);
    })

    this.userService.getUserTotalPortofolioValueEUR(this.userId).subscribe(res => {
      console.log(res);
      this.totalBalanceInEUR = res;
    })

    this.userService.getUserTotalPortofolioValueUSD(this.userId).subscribe(res => {
      console.log(res);
      this.totalBalanceInUSD = res;
    })

    this.walletService.getWalletsByUserId(this.userId).subscribe(res => {
      console.log("Logged user wallets from balance component:");
      console.log(res);
      this.dataSource = new MatTableDataSource(res);
      console.log(this.dataSource);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    })

    localStorage.setItem("isOnBalancePage", "true");
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  getWalletValueInEur(walletId: string) {

    /*this.valueInEurSubscription = this.walletService.getWalletValueInEur(walletId).subscribe(res => {
      console.log("Fut:");
      console.log(res);
      return res;
    })*/

    return 0;
  }

  ngOnDestroy(): void{
    this.route.params.subscribe().unsubscribe();
    this.valueInEurSubscription.unsubscribe();
  }

}


