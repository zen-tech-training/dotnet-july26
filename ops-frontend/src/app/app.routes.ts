//File: src/app/app.routes.ts
import { Routes } from '@angular/router';
export const routes: Routes = [
    {
        path: '',  //root route
        loadComponent: () =>
            import('./features/home/home')
                .then(m => m.Home)
    },
    {
        path: 'login',
        loadComponent: () =>
            import('./features/auth/login/login')
                .then(m => m.Login)
    },
    {
        path: '**',  //It will handle all non matching routes
        redirectTo: '' //Redirect to root route
    }
];