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
  skip = 0;
  take = 10;
  filters = [
    { name: "Ability", value: 1 },
    { name: "Item", value: 2 },
    { name: "Move", value: 3 },
    { name: "Nature", value: 4 },
    { name: "Pokemon", value: 5 },
    { name: "Team", value: 6 },
    { name: "User", value: 7 },
  ];
  selectedFilter = 5;
  filter = '';

  constructor(private pkmn: PkmnService,
    private teamService: TeamService,
    private dialog: MatDialog) { }

  ngOnInit() {
    this.getAllTeams();
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
            this.getMyTeams();
          })
      }
    })
  }

  getAllTeams() {
    this.loading = true;

    this.teamService.getAllTeams(this.skip, this.take)
      .subscribe(x => {
        this.loading = false;
        this.teams = x;
      })
  }

  getMyTeams() {
    const userId = localStorage.getItem('userId');
    
    this.loading = true;
    this.teamService.getMyTeams(userId)
      .subscribe(x => {
        this.loading = false;
        this.teams = x;
      });
  }

  filterByUser(userName: string) {
    this.selectedFilter = 7;
    this.filter = userName;

    this.loading = true;
    this.teamService.getTeamsForUser(this.skip, this.take, userName)
      .subscribe(result => {
        this.loading = false;
        this.teams = result;
      });
  }

  hasControls(team: Team): boolean {
    return localStorage.getItem('username') === team.userName;
  }

}
