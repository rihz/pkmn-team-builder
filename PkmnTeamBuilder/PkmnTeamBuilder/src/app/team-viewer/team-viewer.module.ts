import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeamViewerComponent } from './team-viewer.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { PkmnService } from '../shared/services/pkmn.service';
import { viewerRoute } from './team-viewer.routing';
import { MatButtonModule, MatIconModule, MatCardModule, MatRippleModule, MatSelectModule, MatInputModule } from '@angular/material';
import { TeamService } from '../shared/services/team.service';
import { TeamBuilderModule } from '../team-builder/team-builder.module';
import { SingleTeamComponent } from './single-team/single-team.component';

@NgModule({
  declarations: [TeamViewerComponent, SingleTeamComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    viewerRoute,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatRippleModule,
    MatSelectModule,
    MatInputModule
  ],
  providers: [
    PkmnService, 
    TeamService
  ]
})
export class TeamViewerModule { }
