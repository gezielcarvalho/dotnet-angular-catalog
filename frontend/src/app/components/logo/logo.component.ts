import { Component, Input } from '@angular/core';
import { faCoffee, faFolder, faHome } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-logo',
  templateUrl: './logo.component.html',
})
export class LogoComponent {
  faCoffee = faCoffee;
  faFolder = faFolder;
  faHome = faHome;
  @Input() imagePath: string = '';
}
