// src/app/core/services/assets.service.ts
import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TokenService } from '../../shared/TokenService';

@Injectable({
  providedIn: 'root'
})
export class AssetsService {
  private http = inject(HttpClient);
  private tokenService = inject(TokenService);
  private baseUrl: string = "https://localhost:7172";

  getAssets(page: number, size: number): Observable<AssetsResponse> {
    const token = this.tokenService.getToken();
  
    if (!token) throw new Error('Token não encontrado!');
  
    const headers = new HttpHeaders()
    .set("Authorization", `Bearer ${token}`);

    console.log(headers)
    return this.http.get<AssetsResponse>(
      `${this.baseUrl}/api/v1/orders/by-user?pageNumber=${page}&pageSize=${size}`,
      { headers }
    );
  }

  getAuthHeaders() {
    const token = this.tokenService.getToken();
    return {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${token}`
      })
    };
  }
}

export interface Asset {
  id: number;
  bondAsset: string;
  index: string;
  quantity: number;
  status: string;
  unitPrice: number;
}

export interface AssetsResponse {
  items: Asset[];
  totalElements: number;
  pageNumber: number;
  pageSize: number;
}
