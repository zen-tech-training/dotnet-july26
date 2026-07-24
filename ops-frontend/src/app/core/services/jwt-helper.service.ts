//File: src/app/core/services/jwt-helper.service.ts
import { Injectable } from '@angular/core';
import { JwtPayload } from '../models/auth/jwt-payload';
import { TokenStorageService } from './token-storage.service';
@Injectable({
  providedIn: 'root',
})
export class JwtHelperService {
  
  constructor(private tokenStorage: TokenStorageService) {}

  getToken(): string | null {
    return this.tokenStorage.getToken();
  }
  decodeToken(): JwtPayload | null {
    const token = this.getToken();
    if (!token) return null;
    try {
      const payload = token.split('.')[1]; // "Header.Payload.Signature" ==> Payload
      const json = atob(payload.replace(/-/g, '+').replace(/_/g, '/'));
      return JSON.parse(json);
    } catch {
      return null;
    }
  }
  getUserName(): string {
    // return this.decodeToken()?.unique_name ?? '';
    // return this.decodeToken()?.username ?? '';

    // Safely look up the schema claim string or fall back to unique_name
    const token = this.decodeToken();
    return token ? token['http://xmlsoap.org'] || token.unique_name : '';
  }

  getUserId(): string {
    // return this.decodeToken()?.sub ?? '';

    const token = this.decodeToken();
    return token ? token['http://xmlsoap.orgidentifier'] || token.sub : '';
  }

  getRole(): string {
    // return this.decodeToken()?.role ?? '';

    const token = this.decodeToken();
    return token ? token['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] : '';
  }
  isLoggedIn(): boolean {
    return this.decodeToken() != null;
  }
  isAdmin(): boolean {
    return this.getRole() === 'Admin';
  }
  isSuperUser(): boolean {
    return this.getRole() === 'SuperUser';
  }
  canManageProducts(): boolean {
    return this.isAdmin() || this.isSuperUser();
  }

  deleteToken(): void {
    this.tokenStorage.clear();
  }
}
