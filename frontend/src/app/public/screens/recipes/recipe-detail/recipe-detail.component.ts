import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatMenuModule } from '@angular/material/menu';
import { Recipe } from 'src/app/shared/models/recipe.model';
import { RecipeService } from 'src/app/shared/services/recipe.service';

@Component({
    standalone: true,
    imports: [MatMenuModule, CommonModule],
    selector: 'app-recipe-detail',
    templateUrl: './recipe-detail.component.html',
    styleUrls: ['./recipe-detail.component.css'],
})
export class RecipeDetailComponent implements OnInit {
    @Input() recipe: Recipe | undefined;
    constructor(private service: RecipeService) {}
    ngOnInit() {
        // TODO
    }

    onAddToShoppingList() {
        this.service.addIngredientsToShoppingList(this.recipe!.ingredients);
    }

    onEditRecipe() {
        console.log('RecipeDetailComponent.onEditRecipe');
    }

    onDeleteRecipe() {
        console.log('RecipeDetailComponent.onDeleteRecipe');
    }
}
