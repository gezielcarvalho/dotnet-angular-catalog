import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { RecipeItemComponent } from './recipe-item/recipe-item.component';
import { Recipe } from '../../../../shared/models/recipe.model';
import { CommonModule } from '@angular/common';
import { RecipeService } from 'src/app/shared/services/recipe.service';

@Component({
    standalone: true,
    imports: [RecipeItemComponent, CommonModule],
    selector: 'app-recipe-list',
    templateUrl: './recipe-list.component.html',
})
export class RecipeListComponent implements OnInit {
    @Output() recipeWasSelected = new EventEmitter<Recipe>();
    recipes: Recipe[] | undefined;

    constructor(private service: RecipeService) {}

    ngOnInit() {
        this.recipes = this.service.getRecipes();
    }

    onRecipeSelected(recipe: Recipe) {
        console.log('RecipeListComponent.onRecipeSelected');
        this.recipeWasSelected.emit(recipe);
    }
}
