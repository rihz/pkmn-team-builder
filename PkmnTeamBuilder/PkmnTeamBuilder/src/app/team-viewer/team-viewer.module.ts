import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeamViewerComponent } from './team-viewer.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { PkmnService } from '../shared/services/pkmn.service';
import { viewerRoute } from './team-viewer.routing';
import { MatButtonModule, MatIconModule, MatCardModule } from '@angular/material';
import { TeamService } from '../shared/services/team.service';
import { ReadonlyTeamComponent } from './readonly-team/readonly-team.component';
import { TeamBuilderModule } from '../team-builder/team-builder.module';



@NgModule({
  declarations: [TeamViewerComponent, ReadonlyTeamComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    viewerRoute,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    TeamBuilderModule
  ],
  providers: [
    PkmnService, 
    TeamService
  ]
})
export class TeamViewerModule { }
