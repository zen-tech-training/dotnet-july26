//File: src/app/features/auth/login/login.ts
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { AuthService } from '../../../core/services/auth.service';
import { Router } from '@angular/router';
import { TokenStorageService } from '../../../core/services/token-storage.service';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatCardModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatCheckboxModule,
    MatIconModule,
  ],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  hidePassword = true;
  loginForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private tokenStorage: TokenStorageService,
    private router: Router,
  ) {
    this.loginForm = this.fb.group({
      userName: ['user5', [Validators.required]],
      password: ['123456', [Validators.required]],
      rememberMe: [false],
    });
  }
  onSubmit(): void {
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }
    const request = this.loginForm.value;
    this.authService.login(request).subscribe({
      next: (response) => {
        console.log(response);
        alert('Login Successful');
        // localStorage.setItem('token', response.token);
        this.tokenStorage.setToken(response.token);
        // localStorage.setItem('new', 'some random data');
        setTimeout(() => {
          this.router.navigate(['/']);
        }, 3000);
      },
      error: (error) => {
        console.error(error);
        alert('Invalid Username or Password');
      },
    });
  }

  logout() {
    this.tokenStorage.clear();
    this.router.navigate(['/login']);
  }
}
