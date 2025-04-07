import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as AuthActions from './auth.actions';
import { catchError, map, mergeMap, of, tap } from 'rxjs';
import { Router } from '@angular/router';
import { TokenService } from '../../../shared/TokenService';
import { AuthService } from '../../../core/services/Auth/auth.service';

@Injectable()
export class AuthEffects {
  login$;
  loginSuccess$;
  logout$;

  constructor(
    private actions$: Actions,
    private authService: AuthService,
    private tokenService: TokenService,
    private router: Router
  ) {
    this.login$ = createEffect(() =>
        this.actions$.pipe(
          ofType(AuthActions.login),
          tap(() => console.log('Login action detectado')),
          mergeMap(({ accountId, clientId }) =>
            this.authService.login(accountId, clientId).pipe(
              tap((res) => console.log('Resposta da API:', res)),
              map(response =>
                AuthActions.loginSuccess({
                  token: response.accessToken,
                  expiresIn: response.expiresIn,
                })
              ),
              catchError(error => {
                console.error('Erro no effect:', error);
                return of(AuthActions.loginFailure({ error }));
              })
            )
          )
        )
      );
      

    this.loginSuccess$ = createEffect(
      () =>
        this.actions$.pipe(
          ofType(AuthActions.loginSuccess),
          tap(({ token }) => {
            //localStorage.setItem('token', token);
            tokenService.setToken(token);

            this.router.navigate(['/dashboard']);
          })
        ),
      { dispatch: false }
    );

    this.logout$ = createEffect(
      () =>
        this.actions$.pipe(
          ofType(AuthActions.logout),
          tap(() => {
            localStorage.removeItem('token');
            this.router.navigate(['/auth/login']);
          })
        ),
      { dispatch: false }
    );
  }
}


