import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router'; 

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ProductsComponent } from './products/products.component';
import { HeaderComponent } from './components/header/header.component';
import { NavigationComponent } from './components/header/navigation/navigation.component';
import { SidebarComponent } from './components/header/sidebar/sidebar.component';
import { LogoComponent } from './components/logo/logo.component';


@NgModule({
  declarations: [
    AppComponent, ProductsComponent, HeaderComponent, NavigationComponent, SidebarComponent, LogoComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, AppRoutingModule, RouterModule, 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
