import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
    FormControl,
    FormGroup,
    ReactiveFormsModule,
    Validators,
} from '@angular/forms';

@Component({
    standalone: true,
    imports: [NgFor, NgIf, ReactiveFormsModule],
    selector: 'app-reactive-form',
    templateUrl: './reactive-form.component.html',
})
export class ReactiveFormComponent implements OnInit {
    onSubmit() {
        console.log(this.signupForm.value);
    }
    genders = ['male', 'female', 'other'];
    signupForm!: FormGroup;
    ngOnInit(): void {
        this.signupForm = new FormGroup({
            username: new FormControl(null, Validators.required),
            email: new FormControl(null, [
                Validators.required,
                Validators.email,
            ]),
            gender: new FormControl('female'),
        });
    }
}
