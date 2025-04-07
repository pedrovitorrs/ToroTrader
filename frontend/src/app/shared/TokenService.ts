import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { TokenModel } from './TokenModel';
import { jwtDecode } from 'jwt-decode';

@Injectable({ providedIn: 'root' })
export class TokenService {
  private tokenSubject = new BehaviorSubject<string | null>(null);
  private subjectToken: BehaviorSubject<TokenModel> = new BehaviorSubject(
    {} as TokenModel
  );

  setToken(token: string) {
    localStorage.setItem('token', token);

    this.translateToken(token);
    this.tokenSubject.next(token);
  }

  getToken(): string | null {
    return this.tokenSubject.value ?? localStorage.getItem('token');
  }

  token$(): Observable<string | null> {
    return this.tokenSubject.asObservable();
  }

  public readonly dadosToken$ = this.subjectToken.asObservable();

  isAuthenticated(): boolean {
    return !!this.getToken();
  }

  private translateToken(tokenResponse: string) {
    var token: TokenModel = jwtDecode(tokenResponse);
    console.log(token);
    token.expirationFormated = new Date();

    token.refreshTokenInMS =
      new Date(token.expirationFormated).getTime() -
      new Date().getTime() -
      3 * 60000; // 3 minutos pra refresh token tempo em milisegundos

    localStorage.setItem('tokenModel', JSON.stringify(token));

    this.subjectToken.next(token);
  }
}
