import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { LoginRequest } from 'src/app/models/loginRequest';
import { ToastType } from 'src/app/models/toastType.enum';

@Component({
  selector: 'app-login',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css'],
})
export class LoginPageComponent {
  loginForm: FormGroup;
  loading = false;

  toastMessage = '';
  toastType: ToastType = ToastType.Danger;
  toastVisible = false;

  constructor(
    private authService: AuthService,
    private router: Router,
    private fb: FormBuilder
  ) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.loginForm.invalid) return;

    this.loading = true;

    const { username, password } = this.loginForm.value;
    const loginRequest = new LoginRequest(username, password);

    this.authService.login(loginRequest).subscribe({
      next: (token: string) => {
        localStorage.setItem('jwtToken', token);

        this.toastMessage = 'Uspesno ste prijavljeni!';
        this.toastType = ToastType.Success;
        this.toastVisible = true;

        this.router.navigate(['/']);
      },
      error: (err) => {
        console.error('Login failed', err);

        this.toastMessage =
          'Neuspešna prijava. Proverite korisničko ime i lozinku.';
        this.toastType = ToastType.Danger;
        this.toastVisible = true;

        this.loading = false;
      },
      complete: () => {
        this.loading = false;
      },
    });
  }
}
