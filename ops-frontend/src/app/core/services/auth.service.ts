//File: src/app/core/services/auth.service.ts
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { LoginRequest } from '../models/auth/login-request';
import { LoginResponse } from '../models/auth/login-response';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends ApiService {
  
  login(request: LoginRequest): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(
      `${this.apiUrl}/Auth/login`,
      request
      // {
      //   "userName": "user5",
      //   "password": "123456"
      // }
    );
  }
}

//http.post<DataTypeOfResponse>( backendAPI, payload)