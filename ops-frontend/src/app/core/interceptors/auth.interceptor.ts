//File path: src/app/core/interceptors/auth.interceptor.ts
import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { TokenStorageService } from '../services/token-storage.service';
export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const tokenService = inject(TokenStorageService);
  const token = tokenService.getToken();
  if (!token) {
    return next(req);
  }
  const clonedRequest = req.clone({
    setHeaders: {
      Authorization: `Bearer ${token}`
    }
  });
  return next(clonedRequest);
};