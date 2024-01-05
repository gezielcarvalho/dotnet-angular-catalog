import { Component, OnDestroy, OnInit } from '@angular/core';
import { faLock, faLockOpen } from '@fortawesome/free-solid-svg-icons';
import { AuthService } from 'src/app/shared/services/auth.service';
import { SidebarIconComponent } from '../../sidebar/sidebar-icon/sidebar-icon.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { Subscription } from 'rxjs';

@Component({
    standalone: true,
    imports: [SidebarIconComponent, FontAwesomeModule],
    selector: 'app-login-button',
    templateUrl: './login-button.component.html',
})
export class LoginButtonComponent implements OnInit, OnDestroy {
    faLock = faLock;
    faLockOpen = faLockOpen;
    // create observable to subscribe to auth service to get login status
    isLoggedInSubscription: Subscription | undefined;
    isLoggedIn = false;

    constructor(private authService: AuthService) {}

    ngOnDestroy(): void {
        this.isLoggedInSubscription?.unsubscribe();
    }

    ngOnInit(): void {
        // subscribe to auth service to get login status
        this.isLoggedInSubscription = this.authService.loggedIn$.subscribe(
            loggedIn => {
                console.log('LoginButtonComponent: loggedIn = ' + loggedIn);
                this.isLoggedIn = loggedIn;
            },
        );
    }

    onLogin() {
        console.log('Login button clicked');
        if (this.isLoggedIn) {
            this.authService.logout();
        } else this.authService.login();
    }
}
