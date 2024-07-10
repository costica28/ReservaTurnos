import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';
import { tap } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  loginForm: FormGroup;

  constructor(private _authService: AuthService, private _router: Router,
    private _formBuilder: FormBuilder ){
      this.loginForm = this._formBuilder.group({
        email: ['', Validators.required],
        contrasena: ['', Validators.required]
      });
    }

    login():void{
      const authRequest = { email: this.loginForm.value.email, contrasena: this.loginForm.value.contrasena};

      this._authService.login(authRequest).subscribe((response:any)=>{
          var token = JSON.stringify(response);
          this._authService.setToken(token);
          this.loginForm.reset();
          this._authService.isLoggedIn();
          this._router.navigate(["/home"]);

      },(error)=> alert(error.error.Message));
    }
}
