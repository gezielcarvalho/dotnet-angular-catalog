import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
    standalone: true,
    imports: [FormsModule],
    selector: 'app-template-form',
    templateUrl: './template-form.component.html',
})
export class TemplateFormComponent {
    suggestUserName() {
        const suggestedName = 'Superuser';
    }

    onSubmit(form: NgForm) {
        console.log(form.form.value);
    }
}
