// src/app/core/services/products.service.ts
import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TokenService } from '../../shared/TokenService';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private http = inject(HttpClient);
  private tokenService = inject(TokenService);
  private baseUrl: string = "https://localhost:7172";

  getTopTraded(page: number, size: number): Observable<ProductResponse> {
    const headers = this.getAuthHeaders();
    return this.http.get<ProductResponse>(
      `${this.baseUrl}/api/v1/products/top-traded?pageNumber=${page}&pageSize=${size}`,
      headers
    );
  }

  getAllProducts(page: number, size: number): Observable<ProductResponse> {
    const headers = this.getAuthHeaders();
    var teste= this.http.get<ProductResponse>(
      `${this.baseUrl}/api/v1/products?pageNumber=${page}&pageSize=${size}`,
      headers
    );
    console.log(teste)
    return teste;
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

export interface Product {
  id: string;
  bondAsset: string;
  index: string;
  tax: number;
  unitPrice: number;
  stock: number;
}

export interface ProductResponse {
  items: Product[];
  totalElements: number;
  pageNumber: number;
  pageSize: number;
}
