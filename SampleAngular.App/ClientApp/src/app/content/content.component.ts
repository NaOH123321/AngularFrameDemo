import { Router, NavigationEnd } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit {

  pageTitle: string = "这是首页";
  pageDesc: string = "";

  constructor(public router: Router) {

    router.events.pipe(filter(event => event instanceof NavigationEnd))
      .subscribe((event: NavigationEnd) => {
        if (event.url == "/home") {
          this.pageTitle = "这是首页";
          this.pageDesc = "";
        } else if (event.url.startsWith("/stock")) {
          this.pageTitle = "股票信息管理";
          this.pageDesc = "可以进行股票的增删改查";
        }
      });
  }
  ngOnInit() {

  }

}


