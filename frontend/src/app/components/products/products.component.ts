import { Component, OnInit } from "@angular/core";
import { ProductService } from "../../services/product.services";
import { StoreService } from "../../services/store.service";
import { Product } from "../../models/Product";

@Component({
  selector: 'app-items',
  templateUrl: './products.component.html',
})
export class ProductsComponent implements OnInit {
  products: Product[] = [];
  constructor(private productService: ProductService, public storeService: StoreService) { }
  ngOnInit(): void {
    this.storeService.pageSizeChanges$
      .subscribe(() => {
        this.storeService.page = 1;
        this.getProducts();
      });

    this.getProducts();
  }
  getProducts(): void {
    this.productService.getProducts(this.storeService.page,
      this.storeService.pageSize)
      .subscribe(itemPayload => {
        this.storeService.products = itemPayload.products;
        this.storeService.count = itemPayload.count;
      });
  }

  onPageChange(newPage: number): void {
    this.storeService.page = newPage;
    this.getProducts();
  }

  onPageSizeChange(): void {
    this.storeService._pageSizeSubject.next(this.storeService.pageSize);
  }

}
