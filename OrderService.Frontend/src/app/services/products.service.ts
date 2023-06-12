import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IProduct } from "../models/product";

@Injectable({
    providedIn: 'root'
})

export class productsService {
    constructor(private http: HttpClient) {

    }

    getAll(): Observable<IProduct[]> {
      return this.http.get<IProduct[]>('https://api.escuelajs.co/api/v1/products')
    }
}
