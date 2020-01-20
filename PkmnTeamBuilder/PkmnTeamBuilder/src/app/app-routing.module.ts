import { NgModule } from '@angular/core';
import { Routes, RouterModule, ExtraOptions } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { AuthGuard } from './auth.guard';
import { TeamBuilderComponent } from './team-builder/team-builder.component';
import { TeamViewerComponent } from './team-viewer/team-viewer.component';
import { HomeComponent } from './home/home.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'account', loadChildren: './account/account.module#AccountModule' },
  { path: 'build', loadChildren: './team-builder/team-builder.module#TeamBuilderModule' },
  { path: 'teams', loadChildren: './team-viewer/team-viewer.module#TeamViewerModule' }
];

const config: ExtraOptions = {
  onSameUrlNavigation: 'reload'
};

@NgModule({
  imports: [RouterModule.forRoot(routes, config)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
