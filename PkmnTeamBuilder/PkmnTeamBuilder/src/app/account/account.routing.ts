import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';

export const routing: ModuleWithProviders = RouterModule.forChild([
  { path: 'register', component: SignupComponent},
  { path: 'login', component: LoginComponent },
  { path: 'profile', component: ProfileComponent }
]);