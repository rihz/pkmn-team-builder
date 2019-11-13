import { NgModule } from '@angular/core';
import { Routes, RouterModule, ExtraOptions } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { AuthGuard } from './auth.guard';
import { TeamBuilderComponent } from './team-builder/team-builder.component';


const routes: Routes = [
  { path: '', component: TeamBuilderComponent, canActivate: [AuthGuard] },
  { path: 'account', loadChildren: './account/account.module#AccountModule' },
  { path: 'builder', loadChildren: './team-builder/team-builder.module#TeamBuilderModule', canActivate: [AuthGuard] }
];

const config: ExtraOptions = {
  onSameUrlNavigation: 'reload'
};

@NgModule({
  imports: [RouterModule.forRoot(routes, config)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
