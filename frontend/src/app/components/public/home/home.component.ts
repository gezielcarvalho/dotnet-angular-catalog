import { Component, OnInit } from '@angular/core';
import { RecipesComponent } from '../recipes/recipes.component';
import { ShoppingListComponent } from '../recipes/shopping-list/shopping-list.component';
import { ToolbarComponent } from '../shared/toolbar/toolbar.component';

@Component({
    standalone: true,
    imports: [RecipesComponent, ShoppingListComponent, ToolbarComponent],
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
    ngOnInit(): void {
        //throw new Error("Method not implemented.");
    }
}
