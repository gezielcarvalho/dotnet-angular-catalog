import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { RecipeItemComponent } from './recipe-item/recipe-item.component';
import { Recipe } from '../../../../shared/models/recipe.model';
import { CommonModule } from '@angular/common';

@Component({
    standalone: true,
    imports: [RecipeItemComponent, CommonModule],
    selector: 'app-recipe-list',
    templateUrl: './recipe-list.component.html',
})
export class RecipeListComponent implements OnInit {
    @Output() recipeWasSelected = new EventEmitter<Recipe>();
    recipes: Recipe[] = [
        new Recipe(
            'A Test Recipe 1',
            'This is simply a test one',
            'https://picsum.photos/200',
        ),
        new Recipe(
            'A Test Recipe 2',
            'This is simply a test two',
            'https://picsum.photos/200',
        ),
    ];
    constructor() {}
    ngOnInit() {
        // TODO
    }

    onRecipeSelected(recipe: Recipe) {
        console.log('RecipeListComponent.onRecipeSelected');
        this.recipeWasSelected.emit(recipe);
    }
}
