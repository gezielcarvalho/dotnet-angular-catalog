import { Component, OnInit } from "@angular/core";
import { ProductService } from "../../services/product.services";
import { StoreService } from "../../services/store.service";

@Component({
  selector: 'app-items',
  templateUrl: './products.component.html',
})
export class ProductsComponent implements OnInit {
  products: any = [];
  constructor(private productService: ProductService, public storeService: StoreService) { }
  ngOnInit(): void {
    this.getProducts();
  }
  getProducts(): void {
    this.productService.getProducts()
      .subscribe(products => {
        this.storeService.products = products
      });
  }

}
