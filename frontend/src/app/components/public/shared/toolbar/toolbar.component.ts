import { Component, OnInit } from '@angular/core';
import { MatMenuModule } from '@angular/material/menu';

@Component({
    standalone: true,
    imports: [MatMenuModule],
    selector: 'app-toolbar',
    templateUrl: './toolbar.component.html',
})
export class ToolbarComponent implements OnInit {
    constructor() {}

    ngOnInit() {
        // TODO
    }
}
