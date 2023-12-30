import { Component, Input } from '@angular/core';
import { faCoffee, faFolder, faHome } from '@fortawesome/free-solid-svg-icons';

@Component({
    standalone: true,
    selector: 'app-logo',
    templateUrl: './logo.component.html',
})
export class LogoComponent {
    faCoffee = faCoffee;
    faFolder = faFolder;
    faHome = faHome;
    imagePath: string = 'assets/images/logo_sabre_256.png';
}
