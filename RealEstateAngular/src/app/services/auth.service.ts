import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginRequest } from '../models/loginRequest';
import { RegisterRequest } from '../models/registerRequest';
import { jwtDecode } from 'jwt-decode';
import { UserInfo } from '../models/userInfo';

interface JwtPayload {
  sub: string;
  userId: string;
  role?: string;
  fullName: string;
  contactNumber: string;
  emailAddress: string;
  exp: number;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private httpClient: HttpClient) {}

  login(loginRequest: LoginRequest) {
    return this.httpClient.post(
      'http://localhost:5157/auth/login',
      loginRequest,
      { responseType: 'text' }
    );
  }

  register(registerRequest: RegisterRequest) {
    return this.httpClient.post(
      'http://localhost:5157/auth/register',
      registerRequest,
      { responseType: 'text' }
    );
  }

  logout() {
    localStorage.removeItem('jwtToken');
  }

  getToken(): string | null {
    return localStorage.getItem('jwtToken');
  }

  getUserInfo(): UserInfo | null {
    const token = this.getToken();
    if (!token) return null;

    const payload: JwtPayload = jwtDecode(token);
    const fullName = payload.fullName ?? '';
    const emailAddress = payload.emailAddress ?? '';
    const contactNumber = payload.contactNumber ?? '';

    return new UserInfo(fullName, contactNumber, emailAddress);
  }

  isLoggedIn(): boolean {
    const token = this.getToken();
    if (!token) return false;

    const payload: JwtPayload = jwtDecode(token);
    const now = Math.floor(Date.now() / 1000);
    return payload.exp > now;
  }

  getRole(): string | null {
    const token = this.getToken();
    if (!token) return null;

    const payload: JwtPayload = jwtDecode(token);
    return payload.role ?? null;
  }
}
