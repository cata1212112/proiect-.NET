import {Component, OnInit} from '@angular/core';
import {UserRegister} from "../../../DTOs/UserRegister";
import { FormBuilder, Validators } from '@angular/forms';
import {ApiService} from "../../../core/services/api.service";
import {AuthService} from "../../../core/services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit{

  public registerForm = this.formBuilder.group({
    userName: ['', Validators.required],
    email: ['', Validators.compose([Validators.email, Validators.required])],
    password: ['', Validators.required],
    firstName : ['', Validators.required],
    lastName : ['', Validators.required]
  });

  public hide: Boolean = true;
  errorMessage: any = null;

  private user: UserRegister = new UserRegister();

  constructor(private readonly formBuilder: FormBuilder, private readonly authservice:AuthService, private router: Router) {

  }

  onSubmit() {}


  getFormValidationError(keys: any) {
    keys.forEach((key: any) => {
      const controlErrors = this.registerForm.get(key)?.errors;
      if (controlErrors != null) {
        console.error(key + ' has errors: ' + controlErrors);
      }
    })
  }
  checkForm() {
    this.getFormValidationError(['userName', 'email', 'password', 'firstName', 'lastName']);
    this.user.username = this.registerForm.get('userName')?.value;
    this.user.firstName = this.registerForm.get('firstName')?.value;
    this.user.username = this.registerForm.get('userName')?.value;
    this.user.email = this.registerForm.get('email')?.value;
    this.user.password = this.registerForm.get('password')?.value;
    console.log(this.user);
    this.authservice.registerUser(this.user).subscribe(response => {
      this.errorMessage = null;
      this.router.navigate(['/home']);
    }, error => {console.log(error.error); this.errorMessage = error.error;});
  }

  ngOnInit(): void {
  }
}
