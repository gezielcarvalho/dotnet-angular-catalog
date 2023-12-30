import { Component, OnInit } from '@angular/core';
import { RecipeItemComponent } from './recipe-item/recipe-item.component';
import { Recipe } from '../recipe.model';
import { CommonModule } from '@angular/common';

@Component({
    standalone: true,
    imports: [RecipeItemComponent, CommonModule],
    selector: 'app-recipe-list',
    templateUrl: './recipe-list.component.html',
})
export class RecipeListComponent implements OnInit {
    recipes: Recipe[] = [
        new Recipe(
            'A Test Recipe 1',
            'This is simply a test one',
            'https://pixabay.com/get/gd6910caaccae5f9081c67bc059932055753d0f8e859b31d3b905f61d3d0ba16ecd9c8960588c41771cc99978b0485b9a_1280.jpg',
        ),
        new Recipe(
            'A Test Recipe 2',
            'This is simply a test two',
            'https://pixabay.com/get/gce4cabbd7914dc1b7d37956991d338f7c890ced0119d9fa35a6ea93750f4c9afdfe84a9091ba9d3cb0612de656df4dbd39ba1f805edadb7d6e7b48cd7ee16d3b_1280.jpg',
        ),
    ];
    constructor() {}
    ngOnInit() {
        // TODO
    }
}
