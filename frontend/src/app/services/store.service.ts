import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs/internal/BehaviorSubject";
import { Product } from "../models/Product";

@Injectable({
  providedIn: 'root'
})
export class StoreService {
  private readonly _products = new BehaviorSubject<Product[]>([]);
  readonly products$ = this._products.asObservable();
  get products(): Product[] {
    return this._products.getValue();
  }
  set products(val: Product[]) {
    this._products.next(val);
  }
  constructor() { }
}