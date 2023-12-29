import { ApplicationConfig } from '@angular/core';
import {
  Route,
  provideRouter,
  withEnabledBlockingInitialNavigation,
} from '@angular/router';
import { HomeComponent } from './components/public/products/home/home.component';

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
        (m) => m.ProductsComponent
      ),
  },
];
export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes, withEnabledBlockingInitialNavigation())],
};
