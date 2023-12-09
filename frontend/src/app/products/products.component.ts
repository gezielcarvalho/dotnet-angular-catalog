import { Component, OnInit } from "@angular/core";
import { ProductService } from "./product.services";


@Component({
  selector: 'app-items',
  templateUrl: './products.component.html',
})
export class ProductsComponent implements OnInit {
  products: any = [];
  constructor(private productService: ProductService) { }
  ngOnInit(): void {
    this.getProducts();
  }
  getProducts(): void {
    this.productService.getProducts()
      .subscribe(items => {
        this.products = items;
      });
  }

}
