import { Route } from '@angular/router';
import { HomeComponent } from './public/screens/home/home.component';
import { AuthGuard } from './shared/services/auth-guard.service';

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
        path: 'products/:id',
        loadComponent: () =>
            import(
                './public/screens/products/product-details/product-details.component'
            ).then(m => m.ProductDetailsComponent),
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
    {
        path: 'reserved',
        canActivate: [AuthGuard],
        loadComponent: () =>
            import('./public/screens/reserved/reserved.component').then(
                m => m.ReservedComponent,
            ),
    },
    {
        path: '**',
        redirectTo: '/',
    },
];
