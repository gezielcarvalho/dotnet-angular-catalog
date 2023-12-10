import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router'; 

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HeaderComponent } from './components/header/header.component';
import { NavigationComponent } from './components/header/navigation/navigation.component';
import { SidebarComponent } from './components/header/sidebar/sidebar.component';
import { LogoComponent } from './components/logo/logo.component';
import { ProductDetailsComponent } from './components/products/product-details/product-details.component';
import { ProductsComponent } from './components/products/products.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent, ProductsComponent, HeaderComponent, NavigationComponent, SidebarComponent, LogoComponent, ProductDetailsComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, AppRoutingModule, RouterModule, FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
