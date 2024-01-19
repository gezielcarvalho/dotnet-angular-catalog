import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
    standalone: true,
    imports: [FormsModule],
    selector: 'app-template-form',
    templateUrl: './template-form.component.html',
})
export class TemplateFormComponent {
    @ViewChild('formExample') formExample!: NgForm;
    suggestUserName() {
        const suggestedName = 'Superuser';
    }

    onSubmit() {
        console.log(this.formExample.value);
    }
}
