import { Component, OnInit } from '@angular/core';
import { ShoppingEditComponent } from './shopping-edit/shopping-edit.component';

@Component({
    standalone: true,
    imports: [ShoppingEditComponent],
    selector: 'app-shopping-list',
    templateUrl: './shopping-list.component.html',
})
export class ShoppingListComponent implements OnInit {
    constructor() {}
    ngOnInit() {
        // TODO
    }
}
