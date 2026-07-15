// src/app/services/api.service.ts

import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
// Define an interface for your expected JSON shape

export interface OpsApiResponse {
  message: string;
  key?: number;
  key2?: string;
}

//In C# - Interface I1 { ............... }
//Client Code - I1 iOne;

@Injectable({
  providedIn: 'root' // Makes it a globally accessible singleton service
})export class ApiService {
  private http = inject(HttpClient);
  private baseUrl = 'https://localhost:6004';

//   int num; // In C#
//   num: int ; // In TS

//In C#,
// Method paramaters - DTs, Return type - DT

  // Method to fetch data from /v3Get
  getV3Data(): Observable<OpsApiResponse> {
    return this.http.get<OpsApiResponse>(`${this.baseUrl}/v3Get`);
  }

  // Method to fetch data from /v4Get (Includes credentials for cookies)
  getV4Data(): Observable<OpsApiResponse> {
    return this.http.get<OpsApiResponse>(`${this.baseUrl}/v4Get`, {
      withCredentials: true 
    });
  }
}