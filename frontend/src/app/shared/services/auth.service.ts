import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    private loggedInSubject = new BehaviorSubject<boolean>(false);
    public loggedIn$ = this.loggedInSubject.asObservable();

    loggedIn = false;
    constructor() {}

    isAuthenticated(): Promise<boolean> {
        const promise: Promise<boolean> = new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve(this.loggedInSubject.value);
            }, 800);
        });
        return promise;
    }

    login() {
        this.loggedInSubject.next(true);
    }

    logout() {
        this.loggedInSubject.next(false);
    }
}
