import { Component } from '@angular/core';
import { faHome, faCube } from '@fortawesome/free-solid-svg-icons';
import { SidebarIconComponent } from './sidebar-icon/sidebar-icon.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { RouterModule } from '@angular/router';

@Component({
    standalone: true,
    imports: [SidebarIconComponent, FontAwesomeModule, RouterModule],
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html',
})
export class SidebarComponent {
    faHome = faHome;
    faCube = faCube;
}
