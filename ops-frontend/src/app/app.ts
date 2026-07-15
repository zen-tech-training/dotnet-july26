//File path: ops-frontend/src/app/app.ts

import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { GetDataFromAPI } from './component/get-data-from-api/get-data-from-api';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, GetDataFromAPI],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('ops-frontend');
}
