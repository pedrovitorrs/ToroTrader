// src/app/core/services/assets.service.ts
import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TokenService } from '../../shared/TokenService';
import { environment } from '../../../src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AssetsService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl;

  getAssets(page: number, size: number): Observable<AssetsResponse> {
    return this.http.get<AssetsResponse>(
      `${this.baseUrl}/api/v1/orders/by-user?pageNumber=${page}&pageSize=${size}`
    );
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
