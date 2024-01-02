import { Injectable } from '@angular/core';
import { Recipe } from '../models/recipe.model';

@Injectable({
    providedIn: 'root',
})
export class RecipeService {
    private recipes: Recipe[] = [
        new Recipe(
            'A Test Recipe 1',
            'This is simply a test one',
            'https://picsum.photos/id/237/200/300',
        ),
        new Recipe(
            'A Test Recipe 2',
            'This is simply a test two',
            'https://picsum.photos/id/236/200/300',
        ),
    ];
    constructor() {}

    getRecipes() {
        return this.recipes.slice();
    }
}
