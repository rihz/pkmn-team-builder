import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeamViewerComponent } from './team-viewer.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { PkmnService } from '../shared/services/pkmn.service';
import { viewerRoute } from './team-viewer.routing';
import { MatButtonModule, MatIconModule, MatCardModule, MatRippleModule } from '@angular/material';
import { TeamService } from '../shared/services/team.service';
import { TeamBuilderModule } from '../team-builder/team-builder.module';
import { TeamCardComponent } from './team-card/team-card.component';



@NgModule({
  declarations: [TeamViewerComponent, TeamCardComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    viewerRoute,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatRippleModule
  ],
  providers: [
    PkmnService, 
    TeamService
  ]
})
export class TeamViewerModule { }
