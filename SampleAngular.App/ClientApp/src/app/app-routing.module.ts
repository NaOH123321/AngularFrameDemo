import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StockManagerComponent } from './stock/stock-manager/stock-manager.component';
import { HomeComponent } from './home/home.component';
import { StockFormComponent } from './stock/stock-form/stock-form.component';

const routes: Routes = [
  { path: "", redirectTo: "/home", pathMatch: "full" },
  { path: "home", component: HomeComponent },
  { path: "stock", component: StockManagerComponent },
  { path: "stock/:id", component: StockFormComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
