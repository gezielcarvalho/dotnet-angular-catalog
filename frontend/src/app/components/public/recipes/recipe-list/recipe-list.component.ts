import { Component, OnInit } from '@angular/core';
import { RecipeItemComponent } from './recipe-item/recipe-item.component';

@Component({
    standalone: true,
    imports: [RecipeItemComponent],
    selector: 'app-recipe-list',
    templateUrl: './recipe-list.component.html',
})
export class RecipeListComponent implements OnInit {
    recipes = [];
    constructor() {}
    ngOnInit() {
        // TODO
    }
}
