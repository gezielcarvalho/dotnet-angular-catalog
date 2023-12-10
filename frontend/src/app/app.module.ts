import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { HeaderComponent } from './components/shared/header/header.component';
import { NavigationComponent } from './components/shared/header/navigation/navigation.component';
import { SidebarComponent } from './components/shared/header/sidebar/sidebar.component';
import { LogoComponent } from './components/shared/logo/logo.component';

import { FormsModule } from '@angular/forms';
import { ProductsComponent } from './components/public/products/products.component';
import { ProductDetailsComponent } from './components/public/products/product-details/product-details.component';
import { SidebarIconComponent } from './components/shared/header/sidebar/sidebar-icon/sidebar-icon.component';


@NgModule({
  declarations: [
    AppComponent, ProductsComponent, HeaderComponent, NavigationComponent, SidebarComponent, SidebarIconComponent, LogoComponent, ProductDetailsComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, AppRoutingModule, RouterModule, FormsModule, FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
