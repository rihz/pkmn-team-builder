import { Component, OnInit, Inject } from '@angular/core';
import { Team } from '../shared/models';
import { PkmnService } from '../shared/services/pkmn.service';
import { MatDialog } from '@angular/material';
import { BooleanDialogComponent } from '../shared/boolean-dialog/boolean-dialog.component';
import { TeamService } from '../shared/services/team.service';

@Component({
  selector: 'team-viewer',
  templateUrl: './team-viewer.component.html',
  styleUrls: ['./team-viewer.component.scss'],
  providers: [TeamService]
})
export class TeamViewerComponent implements OnInit {
  teams: any;
  loading = true;

  constructor(private pkmn: PkmnService,
    private teamService: TeamService,
    private dialog: MatDialog) { }

  ngOnInit() {
    this.getTeams();
  }

  deleteTeam(id: number) {
    const ref = this.dialog.open(BooleanDialogComponent, {
      width: '600px',
      data: {
        message: 'Are you sure you would like to delete this team?'
      }
    });

    ref.afterClosed().subscribe(result => {
      if (result) {
        this.teamService.deleteTeam(id)
          .subscribe(result => {
            this.getTeams();
          })
      }
    })
  }

  getTeams() {
    const userId = localStorage.getItem('userId');
    
    this.loading = true;
    this.teamService.getTeams(userId)
      .subscribe(x => {
        this.loading = false;
        this.teams = x;
      });
  }

}
