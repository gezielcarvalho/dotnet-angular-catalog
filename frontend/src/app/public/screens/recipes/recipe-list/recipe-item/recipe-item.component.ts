import { Component, Input, OnInit } from '@angular/core';
import { Recipe } from 'src/app/shared/models/recipe.model';

@Component({
    standalone: true,
    selector: 'app-recipe-item',
    templateUrl: './recipe-item.component.html',
})
export class RecipeItemComponent implements OnInit {
    @Input() recipe: Recipe | undefined;
    constructor() {}
    ngOnInit() {
        // TODO
    }
}
