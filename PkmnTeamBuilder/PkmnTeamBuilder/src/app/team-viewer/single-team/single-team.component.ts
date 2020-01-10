import { Component, OnInit, OnDestroy } from '@angular/core';
import { TeamService } from '../../shared/services/team.service';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Team } from '../../shared/models';

@Component({
  selector: 'app-single-team',
  templateUrl: './single-team.component.html',
  styleUrls: ['./single-team.component.scss']
})
export class SingleTeamComponent implements OnInit, OnDestroy {
  routes: Subscription;
  team: Team;
  loading = true;

  constructor(
    private teams: TeamService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.routes = this.route.params.subscribe(params => {
      if(params['code']) {
        this.teams.getTeam(params['code'])
          .subscribe(team => {
            this.team = <Team>team;
            this.loading = false;
          }, error => {
            alert(error);
          });
      } else {
        this.loading = false;
      }
    })
  }

  ngOnDestroy() {
    this.routes.unsubscribe();
  }

}
