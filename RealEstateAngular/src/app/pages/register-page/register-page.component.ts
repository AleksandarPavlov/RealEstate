import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterRequest } from 'src/app/models/registerRequest';
import { ToastType } from 'src/app/models/toastType.enum';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css'],
})
export class RegisterPageComponent {
  registerForm: FormGroup;
  loading = false;
  toastMessage = '';
  toastType: ToastType = ToastType.Danger;
  toastVisible = false;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      fullName: ['', Validators.required],
      contactNumber: ['', Validators.required],
      emailAddress: ['', [Validators.required, Validators.email]],
      socialMediaLink: [''],
    });
  }

  onSubmit() {
    if (this.registerForm.invalid) return;

    this.loading = true;

    const formValue = this.registerForm.value;
    const registerRequest = new RegisterRequest(
      formValue.username,
      formValue.password,
      formValue.fullName,
      formValue.contactNumber,
      formValue.emailAddress,
      formValue.socialMediaLink
    );

    this.authService.register(registerRequest).subscribe({
      next: (res) => {
        this.toastMessage = 'Registracija uspešna! Možete se prijaviti.';
        this.toastType = ToastType.Success;
        this.toastVisible = true;

        this.registerForm.reset();
        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.error('Registration failed', err);
        this.toastMessage = 'Registracija neuspešna. Proverite podatke.';
        this.toastType = ToastType.Danger;
        this.toastVisible = true;
      },
      complete: () => {
        this.loading = false;
      },
    });
  }
}
