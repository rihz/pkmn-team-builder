import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { routing } from './account.routing';
import { HttpClient } from '@angular/common/http';
import { MatFormFieldModule, MatInputModule, MatButtonModule, MatCardModule, MatIconModule, MatTooltipModule } from '@angular/material';
import { UserService } from '../shared/services/user.service';
import { SharedModule } from '../shared/shared.module';
import { ProfileComponent } from './profile/profile.component';
import { ThemeService } from '../shared/theme/theme.service';
import { TeamService } from '../shared/services/team.service';

@NgModule({
  declarations: [SignupComponent, LoginComponent, ProfileComponent],
  imports: [
    CommonModule,    
    SharedModule,
    FormsModule,
    routing,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatTooltipModule
  ],
  providers: [UserService, ThemeService, TeamService]
})
export class AccountModule { }