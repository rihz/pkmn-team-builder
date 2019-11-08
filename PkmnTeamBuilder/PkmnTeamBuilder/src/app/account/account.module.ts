import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { routing } from './account.routing';
import { HttpClient } from '@angular/common/http';
import { MatFormFieldModule, MatInputModule, MatButtonModule } from '@angular/material';
import { UserService } from '../shared/services/user.service';

@NgModule({
  declarations: [SignupComponent, LoginComponent],
  imports: [
    CommonModule,    
    FormsModule,
    routing,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  providers: [UserService]
})
export class AccountModule { }