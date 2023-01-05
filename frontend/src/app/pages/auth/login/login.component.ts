import { Component } from '@angular/core';
import {FormBuilder} from "@angular/forms";
import {AuthService} from "../../../core/services/auth.service";
import {UserLogin} from "../../../DTOs/UserLogin";
import {UserRegister} from "../../../DTOs/UserRegister";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  username: string = "";
  password: string = "";

  errorMessage: any = null;

  constructor(private readonly authservice:AuthService, private router: Router) {

  }

  login() {
    let usrlog:UserLogin = new UserLogin(this.username, this.password);
    this.authservice.loginUser(usrlog).subscribe(response => {
      console.log("te ai logat fraiere");
      this.errorMessage = null;
       this.authservice.loginUserLocalStorage(response);
      this.router.navigate(['/home']);
  },
      error => {
        this.errorMessage = error.error;
      });
  }
}
