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
  initialLoad = true;
  _take = 5;
  page = 1;
  total = 0;
  filters = [
    { name: "Ability", value: 1 },
    { name: "Item", value: 2 },
    { name: "Move", value: 3 },
    { name: "Nature", value: 4 },
    { name: "Pokemon", value: 5 },
    { name: "Team", value: 6 },
    { name: "User", value: 7 },
  ];
  _selectedFilter = 5;
  _sortBy = 2;
  filter = '';

  constructor(private pkmn: PkmnService,
    private teamService: TeamService,
    private dialog: MatDialog) { }
  
  get isLoggedIn(): boolean {
    return localStorage.getItem('auth_token') !== '';
  }

  set sortBy(value: number) {
    this._sortBy = value;

    this.refresh();
  }

  get sortBy(): number {
    return this._sortBy;
  }

  set selectedFilter(value: number) {
    this._selectedFilter = value;

    this.refresh();
  }

  get selectedFilter(): number {
    return this._selectedFilter;
  }

  set take(value: number) {
    this._take = value;

    this.refresh();
  }

  get take(): number {
    return this._take;
  }

  get isFirstPage(): boolean {
    return this.page === 1;
  }

  get isLastPage(): boolean {
    return this.page * this.take >= this.total;
  }

  get showing(): string {
    return `Showing 
      ${((this.page - 1) * this.take) + 1} 
      to ${this.page * this.take > this.total 
        ? this.total : this.page * this.take} 
      of ${this.total}`;
  }

  get skip(): number {
    return (this.page - 1) * this.take;
  }

  ngOnInit() {
    this.getAllTeams();
  }

  changeFilter(e: any) {
    this.filter = e.target.value;
    this.page = 1;
    this.refresh();
  }

  previousPage() {
    this.page--;

    this.refresh();
  }

  nextPage() {
    this.page++;

    this.refresh();
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
      .subscribe(result => {
        this.loading = false;
        this.initialLoad = false;
        this.teams = result.teams;
        this.total = result.total;
      })
  }

  getMyTeams() {
    const username = localStorage.getItem('username');
    this._selectedFilter = 7;
    this.filter = username;
    
    this.refresh();
  }

  filterByUser(userName: string) {
    this._selectedFilter = 7;
    this.filter = userName;

    this.loading = true;
    this.teams = [];
    this.page = 1;
    this.teamService.getTeamsForUser(this.skip, this.take, userName)
      .subscribe(result => {
        this.loading = false;
        this.teams = result.teams;
        this.total = result.total;
      });
  }

  

  hasControls(team: Team): boolean {
    return localStorage.getItem('username')
      && localStorage.getItem('username') === team.userName;
  }

  changeLike(teamId: number) {
    const userId = localStorage.getItem('userId');

    if (userId) {
      this.teamService.updateLike(teamId, userId)
        .subscribe(result => {
          let team = this.teams.find(x => x.id === teamId);
          team.likes = result.likes;
          team.likedBy = result.likedBy;
        })
    }
  }

  refresh() {
    this.loading = true;
    this.teams = [];

    this.teamService.getFilteredTeams(this.skip, this.take, 
      this.selectedFilter, this.filter, this.sortBy)
      .subscribe(result => {
        this.loading = false;
        this.teams = result.teams;
        this.total = result.total;
      });
  }

  clearFilter() {
    this.filter = '';
    this.refresh();
  }

}
