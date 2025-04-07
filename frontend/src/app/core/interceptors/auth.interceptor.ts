// src/app/core/interceptors/auth.interceptor.ts
import { HttpHeaders, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { TokenService } from '../../shared/TokenService';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const tokenService = inject(TokenService);
  const token = tokenService.getToken();
  console.log("to aqui Interceptor")
  if (token) {
    const cloned = req.clone({
      headers: new HttpHeaders({
        'Authorization': `Bearer ${token}`
      })
    });
    return next(cloned);
  }

  return next(req);
};
