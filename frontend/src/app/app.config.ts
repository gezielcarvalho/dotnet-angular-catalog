import { ApplicationConfig } from '@angular/core';
import {
    Route,
    provideRouter,
    withEnabledBlockingInitialNavigation,
} from '@angular/router';
import { HomeComponent } from './components/public/home/home.component';

const routes: Route[] = [
    {
        path: '',
        component: HomeComponent,
        pathMatch: 'full', // Ensure this route matches only empty path
    },
    {
        path: 'products',
        loadComponent: () =>
            import('./components/public/products/products.component').then(
                m => m.ProductsComponent,
            ),
    },
    {
        path: 'recipes',
        loadComponent: () =>
            import('./components/public/recipes/recipes.component').then(
                m => m.RecipesComponent,
            ),
    },
    {
        path: 'shopping-list',
        loadComponent: () =>
            import(
                './components/public/recipes/shopping-list/shopping-list.component'
            ).then(m => m.ShoppingListComponent),
    },
];
export const appConfig: ApplicationConfig = {
    providers: [provideRouter(routes, withEnabledBlockingInitialNavigation())],
};
