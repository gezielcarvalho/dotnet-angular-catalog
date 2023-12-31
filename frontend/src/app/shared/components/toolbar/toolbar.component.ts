import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatMenuModule } from '@angular/material/menu';

@Component({
    standalone: true,
    imports: [MatMenuModule],
    selector: 'app-toolbar',
    templateUrl: './toolbar.component.html',
})
export class ToolbarComponent implements OnInit {
    @Output() featureSelected = new EventEmitter<string>();
    constructor() {}

    ngOnInit() {
        // TODO
    }

    onSelect(feature: string) {
        console.log({ feature });
        this.featureSelected.emit(feature);
    }
}
