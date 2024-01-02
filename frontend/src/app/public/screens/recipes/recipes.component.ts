import { Component, OnInit } from '@angular/core';
import { RecipeListComponent } from './recipe-list/recipe-list.component';
import { RecipeDetailComponent } from './recipe-detail/recipe-detail.component';
import { Recipe } from 'src/app/shared/models/recipe.model';
import { CommonModule } from '@angular/common';
@Component({
    standalone: true,
    imports: [RecipeListComponent, RecipeDetailComponent, CommonModule],
    selector: 'app-recipes',
    templateUrl: './recipes.component.html',
})
export class RecipesComponent implements OnInit {
    selectedRecipe: Recipe | undefined;
    constructor() {}
    ngOnInit() {
        // TODO
    }
}
