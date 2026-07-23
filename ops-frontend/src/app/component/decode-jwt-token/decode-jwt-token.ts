//File: src/app/component/decode-jwt-token/decode-jwt-token.ts

import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JwtHelperService } from '../../core/services/jwt-helper.service';

import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';

@Component({
  selector: 'app-decode-jwt-token',
  standalone: true,
  imports: [
    CommonModule, 
    MatCardModule, 
    MatButtonModule, 
    MatIconModule, 
    MatDividerModule
  ],
  templateUrl: './decode-jwt-token.html',
  styleUrl: './decode-jwt-token.scss',
})
export class DecodeJwtToken implements OnInit {
  userName: string = '';
  role: string = '';
  userId: string = '';
  isLoggedIn: boolean = false;

  constructor(private jwtHelperService: JwtHelperService) {}

  ngOnInit() {
    this.updateUserInfo();
  }

  decodeToken() {
    this.updateUserInfo();
    console.log("token = ", this.jwtHelperService.getToken());
    console.log("decoded token = ", this.jwtHelperService.decodeToken());
  }

  // New action function to delete the token and clear the view
  deleteToken() {
    this.jwtHelperService.deleteToken();
    this.updateUserInfo(); // This changes values back to default/empty strings
    console.log("Token deleted successfully.");
  }

  private updateUserInfo() {
    this.userName = this.jwtHelperService.getUserName();
    this.role = this.jwtHelperService.getRole();
    this.userId = this.jwtHelperService.getUserId();
    this.isLoggedIn = this.jwtHelperService.isLoggedIn();
  }
}




// import { Component } from '@angular/core';
// import { JwtHelperService } from '../../core/services/jwt-helper.service';

// @Component({
//   selector: 'app-decode-jwt-token',
//   imports: [],
//   templateUrl: './decode-jwt-token.html',
//   styleUrl: './decode-jwt-token.scss',
// })
// export class DecodeJwtToken {
//   constructor(private jwtHelperService: JwtHelperService) {}

//   decodeToken() {
//     console.log("token = ", this.jwtHelperService.getToken());
//     console.log("decoded token = ", this.jwtHelperService.decodeToken());
//     console.log("user name = ", this.jwtHelperService.getUserName());
//     console.log("role = ", this.jwtHelperService.getRole());
//     console.log("user id = ", this.jwtHelperService.getUserId());
//   }
// }
