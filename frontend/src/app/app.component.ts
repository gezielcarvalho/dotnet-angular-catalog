import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './components/public/home/home.component';
import { HeaderComponent } from './components/public/shared/header/header.component';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [CommonModule, RouterModule, HomeComponent, HeaderComponent],
    templateUrl: './app.component.html',
})
export class AppComponent {
    title = 'ASP.NET Core + Angular Starter';
}
