import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../../../models/Product';
import { ProductService } from '../../../../services/product.services';


@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html'
})
export class ProductDetailsComponent {

  product: Product = { id: 0, name: "", price: 0, category: "", description: "" };

  constructor(
    private route: ActivatedRoute,
    private itemService: ProductService
  ) { }

  ngOnInit(): void {
    this.getProduct();
  }

  getProduct(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (!isNaN(id)) {
      this.itemService.getProduct(id)
        .subscribe(product => this.product = product);
    }
  }  addToCart(): void { }
}
