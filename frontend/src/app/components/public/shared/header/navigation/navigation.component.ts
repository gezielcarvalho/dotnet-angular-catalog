import { Component } from '@angular/core';
import { LogoComponent } from '../logo/logo.component';

@Component({
    standalone: true,
    imports: [LogoComponent],
    selector: 'app-navigation',
    templateUrl: './navigation.component.html',
})
export class NavigationComponent {}
