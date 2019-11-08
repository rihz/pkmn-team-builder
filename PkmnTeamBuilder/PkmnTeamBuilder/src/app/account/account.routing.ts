import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';

export const routing: ModuleWithProviders = RouterModule.forChild([
  { path: 'register', component: SignupComponent},
  { path: 'login', component: LoginComponent }
]);