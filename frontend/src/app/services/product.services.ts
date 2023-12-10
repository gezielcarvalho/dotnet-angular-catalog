import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Product } from '../models/Product';
import { ProductPayload } from '../models/ProductPayload';

const mock_products: ProductPayload = {
  products : [
    {
      id: 1, name: 'Adidas Stan Smith', price: 90.0,
      category: 'Shoes', description: ''
    },
    {
      id: 2, name: 'Nike Air Max', price: 110.0,
      category: 'Shoes', description: ''
    },
    {
      id: 3, name: 'Reebok Sweat Shirt', price: 45.0,
      category: 'Clothes', description: ''
    },
    {
      id: 4, name: 'Puma T-Shirt', price: 30.0,
      category: 'Clothes', description: ''
    },
  ],
  count: 4
};

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  getProducts(page: number, pageSize: number): Observable<ProductPayload> {
    const payload: ProductPayload = {
      products: mock_products.products.slice((page - 1) * pageSize, page * pageSize),
      count: mock_products.products.length
    }
    return of(payload);
  }

  getProduct(id: number): Observable<Product> {
    return of(mock_products.products[id - 1]);
  }
  constructor() { }
}
