import { inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../src/environments/environment';

export interface OrdersRequest {
  productId: string;
  quantity: number;
}

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  constructor(private http: HttpClient) {}
  private baseUrl = environment.apiUrl;

  buyProduct(data: OrdersRequest): Observable<any> {
    return this.http.post(`${this.baseUrl}/api/v1/orders`, data); // ajuste a URL da API conforme necessário
  }
}
