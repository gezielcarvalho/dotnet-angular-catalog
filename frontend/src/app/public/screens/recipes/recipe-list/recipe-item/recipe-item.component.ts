import { Component, Input, OnInit } from '@angular/core';
import { Recipe } from 'src/app/shared/models/recipe.model';
import { RecipeService } from 'src/app/shared/services/recipe.service';

@Component({
    standalone: true,
    selector: 'app-recipe-item',
    templateUrl: './recipe-item.component.html',
})
export class RecipeItemComponent implements OnInit {
    @Input() recipe: Recipe | undefined;

    constructor(private service: RecipeService) {}
    ngOnInit() {
        // TODO
    }

    onRecipeSelected() {
        console.log('RecipeItemComponent.onRecipeSelected');
        this.service.recipeSelected.emit(this.recipe);
    }
}
