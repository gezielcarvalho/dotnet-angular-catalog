import { Component } from '@angular/core';

@Component({
    standalone: true,
    selector: 'app-header',
    templateUrl: './header.component.html',
})
export class HeaderComponent {
    title = 'DS Catalog';
}
