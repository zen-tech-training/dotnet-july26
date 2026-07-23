//File: src/app/app.routes.ts
import { Routes } from '@angular/router';
import { Login } from './features/auth/login/login';

export const routes: Routes = [
    {
        path: '',  //root route
        loadComponent: () =>
            import('./features/home/home')
                .then(m => m.Home)
    },
    {
        path: 'login',
        // loadComponent: () =>import('./features/auth/login/login').then(m => m.Login)
        component: Login
    },
    {
        path: '**',    //It will handle all non matching routes
        redirectTo: '' //Redirect to root route
    }
];


//loadComponent vs loadChildren
//ProfileComponent vs AdminDashboardComponent

//                 vs AdminRoutes.ts file will have Admin related Componnets and their Routes
//                 vs www.abc.com/admin