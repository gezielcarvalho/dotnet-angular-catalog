import { Component, Input, OnInit } from '@angular/core';
import { MatMenuModule } from '@angular/material/menu';
import { Recipe } from 'src/app/shared/models/recipe.model';

@Component({
    standalone: true,
    imports: [MatMenuModule],
    selector: 'app-recipe-detail',
    templateUrl: './recipe-detail.component.html',
    styles: [
        `
            .recipe-card {
                @apply border-2 rounded-md items-center justify-between p-4 m-2 border-b border-gray-200;
            }
        `,
    ],
})
export class RecipeDetailComponent implements OnInit {
    @Input() recipe: Recipe | undefined;
    constructor() {}
    ngOnInit() {
        // TODO
    }
}
