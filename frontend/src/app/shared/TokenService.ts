import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class TokenService {
  private tokenSubject = new BehaviorSubject<string | null>(null);

  setToken(token: string) {
    localStorage.setItem('token', token);
    this.tokenSubject.next(token);
  }

  getToken(): string | null {
    return this.tokenSubject.value ?? localStorage.getItem('token');
  }

  token$(): Observable<string | null> {
    return this.tokenSubject.asObservable();
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }
}
