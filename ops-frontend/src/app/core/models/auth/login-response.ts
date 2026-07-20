//File: src/app/core/models/auth/login-response.ts
export interface LoginResponse {
    token: string;
    userId: number;
    userName: string;
    role: string;
    expiresOn: string;
}