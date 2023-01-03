import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AuthRoutingModule} from "../auth/auth-routing.module";
import {AdminDashboardComponent} from "./admin-dashboard/admin-dashboard.component";
import {UsersComponent} from "./users/users.component";
import {UserComponent} from "./user/user.component";
import {MatLegacyListModule} from "@angular/material/legacy-list";
import {AdminRoutingModule} from "./admin-routing.module";



@NgModule({
  declarations: [AdminDashboardComponent, UsersComponent, UserComponent],
  imports: [
    CommonModule,
    AdminRoutingModule,
    MatLegacyListModule
  ]
})
export class AdminModule { }
