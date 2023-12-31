import { Route } from '@angular/router';
import { HomeComponent } from './public/screens/home/home.component';

export const routes: Route[] = [
    {
        path: '',
        component: HomeComponent,
        pathMatch: 'full',
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
