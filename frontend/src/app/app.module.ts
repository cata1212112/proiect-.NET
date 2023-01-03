import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './pages/admin/user/user.component';
import { UsersComponent } from './pages/admin/users/users.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/auth/login/login.component';
import { AdminDashboardComponent } from './pages/admin/admin-dashboard/admin-dashboard.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { MeniuComponent } from './shared/meniu/meniu.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatLegacyListModule} from "@angular/material/legacy-list";
import {HttpClientModule} from "@angular/common/http";

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MeniuComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatLegacyListModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
