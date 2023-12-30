import { Component, OnInit } from '@angular/core';
import { ShoppingEditComponent } from './shopping-edit/shopping-edit.component';
import { Ingredient } from 'src/app/shared/models/ingredients.model';
import { CommonModule } from '@angular/common';

@Component({
    standalone: true,
    imports: [ShoppingEditComponent, CommonModule],
    selector: 'app-shopping-list',
    templateUrl: './shopping-list.component.html',
})
export class ShoppingListComponent implements OnInit {
    ingredients: Ingredient[] = [
        new Ingredient('Apples', 5),
        new Ingredient('Tomatoes', 10),
    ];
    constructor() {}
    ngOnInit() {
        // TODO
    }
}
