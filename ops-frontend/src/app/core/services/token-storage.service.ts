//File path: src/app/core/services/token-storage.service.ts
import { Injectable } from '@angular/core';
@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {
  private readonly TOKEN_KEY = 'token';
  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY); // localStorage is a Browser API
  }
  setToken(token: string): void {
    localStorage.setItem(this.TOKEN_KEY, token);
    // localStorage.setItem("temp key", "some value");
  }
  clear(): void {
    localStorage.removeItem(this.TOKEN_KEY);
  }
  isLoggedIn(): boolean {
    return !!this.getToken();
  }
}