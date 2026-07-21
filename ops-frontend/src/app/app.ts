//File path: ops-frontend/src/app/app.ts
import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { GetDataFromAPI } from './component/get-data-from-api/get-data-from-api';
import { Navbar } from './shared/components/navbar/navbar';
import ThirdNavbarAlias  from './shared/components/navbar/navbar';
import { UserList } from './features/user-list/user-list';

// import { something } from 'pathOfTsFile'
// import something from 'pathOfTsFile;

//Component decorator
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, GetDataFromAPI, Navbar, UserList],
  // template: `<h1>App Inline Component</h1>`, //Inline componnet; back tick is present just below to ESC button
  templateUrl: './app.html', 
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('Order Prcessing Application');
}
