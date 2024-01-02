import { Component, OnInit } from '@angular/core';
import { ShoppingEditComponent } from './shopping-edit/shopping-edit.component';
import { Ingredient } from 'src/app/shared/models/ingredients.model';
import { CommonModule } from '@angular/common';
import { ShoppingListService } from 'src/app/shared/services/shopping-list.service';

@Component({
    standalone: true,
    imports: [ShoppingEditComponent, CommonModule],
    selector: 'app-shopping-list',
    templateUrl: './shopping-list.component.html',
})
export class ShoppingListComponent implements OnInit {
    ingredients: Ingredient[] = [];
    constructor(private service: ShoppingListService) {}
    ngOnInit() {
        this.ingredients = this.service.getIngredients();
        this.service.ingredientsChanged.subscribe(
            (ingredients: Ingredient[]) => {
                this.ingredients = ingredients;
            },
        );
    }
}
