import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-sidebar-icon',
  templateUrl: './sidebar-icon.component.html',
})
export class SidebarIconComponent {
  @Input() text: string = '';
  @Input() routerLink: string[] | never | undefined;
}
