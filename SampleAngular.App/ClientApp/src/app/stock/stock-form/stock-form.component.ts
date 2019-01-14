import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StockService, Stock } from './../stock.service';
import { FormGroup, FormBuilder, Validators, FormControl, FormArray } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-stock-form',
  templateUrl: './stock-form.component.html',
  styleUrls: ['./stock-form.component.css']
})
export class StockFormComponent implements OnInit {

  stock: Stock = new Stock(0, '', 0, 0, '', []);
  formModel: FormGroup;
  categories = ['IT', '互联网', '金融'];

  constructor(public routerInfo: ActivatedRoute, public router: Router, private stockService: StockService) { }

  ngOnInit() {
    let id = this.routerInfo.snapshot.params["id"];

    let fb = new FormBuilder();
    this.formModel = fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      price: [0, Validators.required],
      desc: [''],
      categories: fb.array([
        false,
        false,
        false
      ], this.categoriesSelectValidator)
    });

    this.stockService.getStockById(id).subscribe(
      data => {
        this.stock = data;
        this.formModel.reset({
          name: data.name,
          price: data.price,
          desc: data.desc,
          categories: [
            data.categories.indexOf(this.categories[0]) != -1,
            data.categories.indexOf(this.categories[1]) != -1,
            data.categories.indexOf(this.categories[2]) != -1
          ]
        });
      }
    );

  }

  categoriesSelectValidator(control: FormArray) {
    let valid = false;
    control.controls.forEach(control => {
      if (control.value) {
        valid = true;
      }
    });
    if (valid) {
      return null;
    }
    else
      return { categorieslength: true }
  }

  cancel() {
    this.router.navigateByUrl("/stock");
  }

  save() {
    let chinesecategories = [];
    let index = 0;
    for (let i = 0; i < 3; i++) {
      if (this.formModel.value.categories[i]) {
        chinesecategories[index++] = this.categories[i];
      }
    }
    this.formModel.value.rating = this.stock.rating;
    this.formModel.value.categories = chinesecategories;
    console.log(JSON.stringify(this.formModel.errors));
    console.log(this.formModel.value);
  }
}
