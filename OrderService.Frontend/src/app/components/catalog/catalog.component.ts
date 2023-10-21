import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from './../../models/product';
import { productsService } from './../../services/products.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent implements OnInit {
  products: IProduct[] =  []
  constructor(private productsService: productsService) { }

  ngOnInit(): void {
    this.productsService.getAll().subscribe( products => {
      this.products = products
    })
  }
}
