//ops-frontend/src/app/component/get-data-from-api/get-data-from-api.ts

import { HttpClient } from '@angular/common/http';
import { Component, inject, signal } from '@angular/core';
import { ApiService, OpsApiResponse } from '../../services/api.service';

@Component({
  selector: 'app-get-data-from-api',
  imports: [],
  templateUrl: './get-data-from-api.html',
  styleUrl: './get-data-from-api.scss',
})
export class GetDataFromAPI {
  private apiService = inject(ApiService);

  // Using Angular Signals for optimal performance in Zoneless mode
  apiData = signal<OpsApiResponse | null>(null);
  errorMessage = signal<string | null>(null);

  onFetchData(): void {
    alert("You called onFetchData()");
    this.apiService.getV3Data().subscribe({
      next: (response) => {
        this.apiData.set(response);
        this.errorMessage.set(null);
      },
      error: (err) => {
        console.error(err);
        this.errorMessage.set('Failed to fetch data from backend.');
      }
    });
  }



}
