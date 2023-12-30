import { Component, OnInit } from '@angular/core';
import { RecipeItemComponent } from './recipe-item/recipe-item.component';
import { Recipe } from '../recipe.model';

@Component({
    standalone: true,
    imports: [RecipeItemComponent],
    selector: 'app-recipe-list',
    templateUrl: './recipe-list.component.html',
})
export class RecipeListComponent implements OnInit {
    recipes: Recipe[] = [
        new Recipe(
            'A Test Recipe',
            'This is simply a test',
            'https://www.maxpixel.net/static/photo/1x/Recipe-Template-Recipe-Book-Blank-Cookbook-Blank-2169308.jpg',
        ),
        new Recipe(
            'A Test Recipe',
            'This is simply a test',
            'https://www.maxpixel.net/static/photo/1x/Recipe-Template-Recipe-Book-Blank-Cookbook-Blank-2169308.jpg',
        ),
    ];
    constructor() {}
    ngOnInit() {
        // TODO
    }
}
