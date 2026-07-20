//File path: ops-frontend/src/app/app.ts

import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { GetDataFromAPI } from './component/get-data-from-api/get-data-from-api';
import { Navbar } from './shared/components/navbar/navbar';
import { UserList } from './features/user-list/user-list';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, GetDataFromAPI, Navbar, UserList],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('ops-frontend');
}
