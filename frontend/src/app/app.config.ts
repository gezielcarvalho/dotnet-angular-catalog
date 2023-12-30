import { ApplicationConfig } from '@angular/core';
import {
    Route,
    provideRouter,
    withEnabledBlockingInitialNavigation,
} from '@angular/router';

import { provideAnimations } from '@angular/platform-browser/animations';
import { HomeComponent } from './public/screens/home/home.component';

const routes: Route[] = [
    {
        path: '',
        component: HomeComponent,
        pathMatch: 'full', // Ensure this route matches only empty path
    },
    {
        path: 'products',
        loadComponent: () =>
            import('./public/screens/products/products.component').then(
                m => m.ProductsComponent,
            ),
    },
    {
        path: 'recipes',
        loadComponent: () =>
            import('./public/screens/recipes/recipes.component').then(
                m => m.RecipesComponent,
            ),
    },
    {
        path: 'shopping-list',
        loadComponent: () =>
            import(
                './public/screens/recipes/shopping-list/shopping-list.component'
            ).then(m => m.ShoppingListComponent),
    },
];
export const appConfig: ApplicationConfig = {
    providers: [
        provideRouter(routes, withEnabledBlockingInitialNavigation()),
        provideAnimations(),
    ],
};
