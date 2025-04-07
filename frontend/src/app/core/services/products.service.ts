// src/app/core/services/products.service.ts
import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl;

  getTopTraded(page: number, size: number): Observable<ProductResponse> {
    return this.http.get<ProductResponse>(
      `${this.baseUrl}/api/v1/products/top-traded?pageNumber=${page}&pageSize=${size}`
    );
  }

  getAllProducts(page: number, size: number): Observable<ProductResponse> {
    var teste= this.http.get<ProductResponse>(
      `${this.baseUrl}/api/v1/products?pageNumber=${page}&pageSize=${size}`
    );
    return teste;
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
