import {
    Component,
    ElementRef,
    EventEmitter,
    OnInit,
    Output,
    ViewChild,
} from '@angular/core';
import { Ingredient } from 'src/app/shared/models/ingredients.model';
import { ShoppingListService } from 'src/app/shared/services/shopping-list.service';

@Component({
    standalone: true,
    selector: 'app-shopping-edit',
    templateUrl: './shopping-edit.component.html',
})
export class ShoppingEditComponent implements OnInit {
    @ViewChild('nameInput') nameInputRef: ElementRef | undefined;
    @ViewChild('amountInput') amountInputRef: ElementRef | undefined;
    constructor(private service: ShoppingListService) {}
    ngOnInit() {
        // TODO
    }

    onAddItem(e: Event) {
        e.preventDefault();
        const ingName = this.nameInputRef!.nativeElement.value;
        const ingAmount = this.amountInputRef!.nativeElement.value;
        const newIngredient = new Ingredient(ingName, ingAmount);
        this.service.addIngredient(newIngredient);
        // clear the input fields
        this.nameInputRef!.nativeElement.value = '';
        this.amountInputRef!.nativeElement.value = '';
        console.log('ShoppingEditComponent.onAddItem');
    }
}
