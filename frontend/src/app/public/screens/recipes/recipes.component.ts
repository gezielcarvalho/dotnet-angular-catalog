import { Component, OnInit } from '@angular/core';
import { RecipeListComponent } from './recipe-list/recipe-list.component';
import { RecipeDetailComponent } from './recipe-detail/recipe-detail.component';
@Component({
    standalone: true,
    imports: [RecipeListComponent, RecipeDetailComponent],
    selector: 'app-recipes',
    templateUrl: './recipes.component.html',
})
export class RecipesComponent implements OnInit {
    constructor() {}
    ngOnInit() {
        // TODO
    }
}
