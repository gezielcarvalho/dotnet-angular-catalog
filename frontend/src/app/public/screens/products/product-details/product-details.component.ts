import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/shared/models/product';
import { ProductService } from 'src/app/shared/services/product.service';

@Component({
    standalone: true,
    selector: 'app-product-details',
    templateUrl: './product-details.component.html',
})
export class ProductDetailsComponent {
    product: Product = {
        id: 0,
        name: '',
        price: 0,
        category: '',
        description: '',
    };

    constructor(
        private route: ActivatedRoute,
        private itemService: ProductService,
    ) {}

    ngOnInit(): void {
        this.getProduct();
    }

    getProduct(): void {
        const id = Number(this.route.snapshot.paramMap.get('id'));
        if (!isNaN(id)) {
            this.itemService
                .getProduct(id)
                .subscribe(product => (this.product = product));
        }
    }
    addToCart(): void {}
}
