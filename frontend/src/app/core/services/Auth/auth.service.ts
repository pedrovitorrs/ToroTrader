import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { catchError, filter, take } from 'rxjs/operators';
import { environment } from '../../../../src/environments/environment';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}


  login(accountId: string, clientId: string): Observable<any> {
    var teste = this.http.post(`${this.baseUrl}/api/v1/auth`, {
      accountId,
      clientId
    }).pipe(
      //filter((response: any) => response && response.success && response.httpCode != 401),
      catchError((error: HttpErrorResponse) => {
        console.error('Erro na autenticação:', error);
        return EMPTY;
      }),
      take(1)
    );

    return teste;
  }
}