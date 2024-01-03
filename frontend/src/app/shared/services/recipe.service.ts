import { EventEmitter, Injectable } from '@angular/core';
import { Recipe } from '../models/recipe.model';
import { Ingredient } from '../models/ingredients.model';
import { ShoppingListService } from './shopping-list.service';

@Injectable({
    providedIn: 'root',
})
export class RecipeService {
    recipeSelected = new EventEmitter<Recipe>();
    private recipes: Recipe[] = [
        new Recipe(
            'A Test Recipe 1',
            'This is simply a test one',
            'https://picsum.photos/id/237/200/300',
            [new Ingredient('Meat', 1), new Ingredient('French Fries', 20)],
        ),
        new Recipe(
            'A Test Recipe 2',
            'This is simply a test two',
            'https://picsum.photos/id/236/200/300',
            [new Ingredient('Buns', 2), new Ingredient('Meat', 1)],
        ),
    ];
    constructor(private shoppingListService: ShoppingListService) {}

    getRecipes() {
        return this.recipes.slice();
    }

    addIngredientsToShoppingList(ingredients?: Ingredient[]) {
        ingredients?.forEach(ingredient => {
            this.shoppingListService.addIngredient(ingredient);
        });
    }
}
