import { ApplicationConfig } from '@angular/core';
import {
    provideRouter,
    withEnabledBlockingInitialNavigation,
} from '@angular/router';

import { provideAnimations } from '@angular/platform-browser/animations';
import { routes } from './app.routing';

export const appConfig: ApplicationConfig = {
    providers: [
        provideRouter(routes, withEnabledBlockingInitialNavigation()),
        provideAnimations(),
    ],
};
