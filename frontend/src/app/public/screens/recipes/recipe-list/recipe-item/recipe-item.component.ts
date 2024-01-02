import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Recipe } from 'src/app/shared/models/recipe.model';

@Component({
    standalone: true,
    selector: 'app-recipe-item',
    templateUrl: './recipe-item.component.html',
})
export class RecipeItemComponent implements OnInit {
    @Input() recipe: Recipe | undefined;
    @Output() receipeSelected = new EventEmitter<void>();
    constructor() {}
    ngOnInit() {
        // TODO
    }

    onRecipeSelected() {
        this.receipeSelected.emit();
        console.log('RecipeItemComponent.onSelected');
    }
}
