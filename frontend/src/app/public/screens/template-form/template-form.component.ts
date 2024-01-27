import { NgIf } from '@angular/common';
import { Component, ViewChild } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
    standalone: true,
    imports: [FormsModule, NgIf],
    selector: 'app-template-form',
    templateUrl: './template-form.component.html',
    styleUrls: ['./template-form.component.css'],
})
export class TemplateFormComponent {
    @ViewChild('formExample') formExample!: NgForm;
    suggestUserName() {
        const suggestedName = 'Superuser';
    }

    onSubmit() {
        console.log(this.formExample);
    }
}
