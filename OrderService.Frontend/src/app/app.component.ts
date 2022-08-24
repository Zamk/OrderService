import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from './models/product';
import { products as data} from './data/products'
import { productsService } from './services/products.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'OrderService.Frontend';
  products: IProduct[] =  []

  constructor(private productsService: productsService) {

  }

  ngOnInit(): void {
    this.productsService.getAll().subscribe( products => {
      this.products = products
    })
  }

}
