import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Stock } from '../stock.service';
import { StockService } from './../stock.service';
import { FormControl } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-stock-manager',
  templateUrl: './stock-manager.component.html',
  styleUrls: ['./stock-manager.component.css']
})
export class StockManagerComponent implements OnInit {

  // stocks: Array<Stock>;
  stocks: Observable<Stock[]>;
  nameFilter: FormControl = new FormControl();
  keyword: string;

  constructor(public router: Router, private stockService: StockService) { }

  ngOnInit() {
    this.stocks = this.stockService.getStocks();
    this.nameFilter.valueChanges.pipe(debounceTime(500)).
      subscribe(value => this.keyword = value);
  }

  create() {
    this.router.navigateByUrl("/stock/0");
  }

  update(stock: Stock) {
    this.router.navigateByUrl("/stock/" + stock.id);
  }

}

