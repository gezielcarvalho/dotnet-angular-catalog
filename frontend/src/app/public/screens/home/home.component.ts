import { Component, OnInit } from '@angular/core';
import { RecipesComponent } from '../recipes/recipes.component';
import { ShoppingListComponent } from '../recipes/shopping-list/shopping-list.component';
import { ToolbarComponent } from 'src/app/shared/components/toolbar/toolbar.component';
import { CommonModule } from '@angular/common';

@Component({
    standalone: true,
    imports: [
        RecipesComponent,
        ShoppingListComponent,
        ToolbarComponent,
        CommonModule,
    ],
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
    ngOnInit(): void {
        //throw new Error("Method not implemented.");
    }
}
