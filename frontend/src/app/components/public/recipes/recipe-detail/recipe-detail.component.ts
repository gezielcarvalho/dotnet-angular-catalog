import { Component, OnInit } from '@angular/core';
import { MatMenuModule } from '@angular/material/menu';

@Component({
    standalone: true,
    imports: [MatMenuModule],
    selector: 'app-recipe-detail',
    templateUrl: './recipe-detail.component.html',
})
export class RecipeDetailComponent implements OnInit {
    constructor() {}
    ngOnInit() {
        // TODO
    }
}
