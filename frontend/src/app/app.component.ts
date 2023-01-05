import { Component } from '@angular/core';
import {LoggedUser} from "./DTOs/LoggedUser";
import {AuthService} from "./core/services/auth.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'frontend';

  constructor(private readonly authservice:AuthService) {
  }

  isLogged() {
    return this.authservice.isLoggedIn();
  }

  isAdmin() {
    return this.authservice.isAdmin();
  }
}
