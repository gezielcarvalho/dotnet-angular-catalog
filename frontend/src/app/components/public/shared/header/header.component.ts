import { Component } from '@angular/core';
import { NavigationComponent } from './navigation/navigation.component';

@Component({
    standalone: true,
    imports: [NavigationComponent],
    selector: 'app-header',
    templateUrl: './header.component.html',
})
export class HeaderComponent {
    title = 'DS Catalog';
}
