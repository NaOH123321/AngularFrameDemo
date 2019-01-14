import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class StockService {

  private stocks = [
    new Stock(1, "第一个股票", 1.99, 3.5, "这是第一个股票", ["金融", "互联网"]),
    new Stock(2, "第二个股票", 5.34, 1.0, "这是第二个股票", ["互联网"]),
    new Stock(3, "第三个股票", 3.64, 2.5, "这是第三个股票", ["IT", "互联网"]),
    new Stock(4, "第四个股票", 23.23, 3.5, "这是第四个股票", ["金融", "互联网"]),
    new Stock(5, "第五个股票", 9.45, 4.5, "这是第五个股票", ["金融", "IT"]),
    new Stock(6, "第六个股票", 5.22, 3.0, "这是第六个股票", ["金融"]),
    new Stock(7, "第七个股票", 1.44, 5.0, "这是第七个股票", ["IT"]),
  ];

  constructor(public http: Http) { }

  getStocks(): Observable<Stock[]> {
    return this.http.get("/api/stock").pipe(map(res => res.json()));
  }

  // getStocks(): Stock[] {
  //   return this.stocks;
  // }

  getStockById(stockId: number): Observable<Stock> {
    return this.http.get("/api/stock/" + stockId).pipe(map(res => res.json()));
  }

  // getStockById(stockId: number) {
  //   var stock = this.stocks.find(stock => stock.id == stockId);
  //   if (!stock) {
  //     stock = new Stock(0, "", 0, 0, "", []);
  //   }
  //   return stock;
  // }
}

export class Stock {
  constructor(public id: number,
    public name: string,
    public price: number,
    public rating: number,
    public desc: string,
    public categories: Array<string>) {
  }
}
