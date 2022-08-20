import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { IProduct } from './models/product';
import { products as data} from './data/products'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  products: IProduct[] = data

  title = 'OrderService.Frontend';
}
