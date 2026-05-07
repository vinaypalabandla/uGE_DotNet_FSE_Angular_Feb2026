import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../models/Product';
 

@Injectable({
  providedIn: 'root'  // Project level and singleton 
})
export class ProductService {

    readonly API_URL:string = "http://localhost:5000/api/Product";

    constructor(private httpClient:HttpClient){}

    getProducts() {
      return this.httpClient.get<Product[]>(this.API_URL);
    }

    getProductById(id:number) {
      return this.httpClient.get<Product>(this.API_URL+ id);
    }

    addProduct(product:Product)     {
      return this.httpClient.post(this.API_URL, product);
    }

  updateProduct(id: number, product: Product) {
  return this.httpClient.put(this.API_URL + id, product);
}

deleteProduct(id: number) {
  return this.httpClient.delete(this.API_URL+ id); 
}

}