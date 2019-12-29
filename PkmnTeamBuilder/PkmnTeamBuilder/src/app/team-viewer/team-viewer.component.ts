import { Component, OnInit } from '@angular/core';
import { Team } from '../shared/models';
import { PkmnService } from '../shared/services/pkmn.service';

@Component({
  selector: 'team-viewer',
  templateUrl: './team-viewer.component.html',
  styleUrls: ['./team-viewer.component.scss']
})
export class TeamViewerComponent implements OnInit {
  teams: any;

  constructor(private pkmn: PkmnService) { }

  ngOnInit() {
    this.getTeams();
  }

  deleteTeam(id: number) {
    this.pkmn.deleteTeam(id)
      .subscribe(result => {
        this.getTeams();
      })
  }

  getTeams() {
    const userId = localStorage.getItem('userId');

    this.pkmn.getTeams(userId)
      .subscribe(x => {
        this.teams = x;
      });
  }

}
