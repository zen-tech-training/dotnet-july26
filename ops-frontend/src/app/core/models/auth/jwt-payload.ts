//File: src/app/core/models/auth/jwt-payload.ts
export interface JwtPayload {
    sub: string;
    unique_name: string;
    username: string;
    role: string;
    exp: number;
    iss: string;
    aud: string;

    // Map the long XML schema keys explicitly
    'http://xmlsoap.org': string;
    'http://xmlsoap.orgidentifier':string;
    'http://schemas.microsoft.com/ws/2008/06/identity/claims/role': string;
}
