import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./pages/home/home.component";
import {RegisterComponent} from "./pages/auth/register/register.component";
import {LoginComponent} from "./pages/auth/login/login.component";
import {AdminModule} from "./pages/admin/admin.module";

import {AuthGuard} from "./core/guards/auth.guard";
import {AdminGuard} from "./core/guards/admin.guard";

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'admin',
    canActivate: [AdminGuard],
    loadChildren: () => import('./pages/admin/admin.module').then(a => a.AdminModule)
  },
  {
    path: 'auth',
    canActivate: [AuthGuard],
    loadChildren: () => import('./pages/auth/auth.module').then(a => a.AuthModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
