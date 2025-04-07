import { inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TokenService } from '../../shared/TokenService';

export interface OrdersRequest {
  productId: string;
  quantity: number;
}

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  constructor(private http: HttpClient) {}
  private tokenService = inject(TokenService);
  private baseUrl: string = "https://localhost:7172";

  buyProduct(data: OrdersRequest): Observable<any> {
    const headers = this.getAuthHeaders();
    return this.http.post(`${this.baseUrl}/api/v1/orders`, data, headers); // ajuste a URL da API conforme necessário
  }

  private getAuthHeaders() {
    const token = this.tokenService.getToken();

    if (!token) throw new Error('Token não encontrado!');

    return {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${token}`
      })
    };
  }
}
