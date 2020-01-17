import { Component, OnInit, OnDestroy, ViewChildren, QueryList } from '@angular/core';
import { Item, TeamMember, Team, Pokemon } from '../shared/models';
import { PkmnService } from '../shared/services/pkmn.service';
import { ThemeService } from '../shared/theme/theme.service';
import { Router, ActivatedRoute } from '@angular/router';
import { TeamService } from '../shared/services/team.service';
import { Subscription } from 'rxjs';
import { TeamMemberComponent } from './team-member/team-member.component';
import { UserService } from '../shared/services/user.service';
import { MatDialog, MatSnackBar } from '@angular/material';
import { CodeDisplayComponent } from './code-display/code-display.component';

@Component({
  selector: 'team-builder',
  templateUrl: './team-builder.component.html',
  styleUrls: ['./team-builder.component.scss'],
  providers: [TeamService]
})
export class TeamBuilderComponent implements OnInit, OnDestroy {
  gen = null;
  team: Team = new Team();
  items: any;
  natures: any;
  _activeTheme: string = '';
  routes: Subscription;
  loading = true;
  code = '';

  constructor(private pkmn: PkmnService,
    private teams: TeamService,
    private themeService: ThemeService,
    private router: Router,
    private route: ActivatedRoute,
    private userService: UserService,
    private dialog: MatDialog,
    private snackbar: MatSnackBar) { }

  get activeTheme() {
    return this._activeTheme;
  }

  set activeTheme(value: string) {
    this._activeTheme = value;
  }

  get duplicate() {
    const arr = this.team.members.map(function (m) { return m.pokemonId });

    return arr.some(function (m, index) {
      return arr.indexOf(m, index + 1) !== -1
    });
  }

  ngOnInit() {
    const ref = this.dialog.open(CodeDisplayComponent, {
      width: '400px',
      data: {
        code: 'a12bvC'
      }
    });
    this.routes = this.route.params.subscribe(params => {
      if (params['code']) {
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
    });

    this.pkmn.getItems()
      .subscribe(x => {
        this.items = x;
      });

    this.pkmn.getNatures()
      .subscribe(x => {
        this.natures = x;
      });

    this.activeTheme = this.themeService.getActiveTheme().name;
  }

  ngOnDestroy() {
    this.routes.unsubscribe();
  }

  setGen(gen: number) {
    this.gen = gen;

    localStorage.setItem('teamBuilderGen', gen.toString());
  }

  addPokemon(pokemon: any) {
    let teamMember = new TeamMember();
    teamMember.pokemonId = pokemon.id;
    teamMember.pokemon = pokemon;

    this.team.members.push(teamMember);
  }

  addExisting(member: TeamMember) {
    this.team.members.push(member);
  }

  removeMember(index: number) {
    this.team.members.splice(index, 1);
  }

  changeMember(index: number, chg: any) {
    if (chg.result === 'pokemon') {
      let teamMember = new TeamMember();

      teamMember.pokemonId = chg.payload.id;
      teamMember.pokemon = chg.payload;

      this.team.members[index] = teamMember;
    } else if (chg.result === 'member') {
      this.team.members[index] = chg.payload;
    }
  }

  save() {
    this.team.errors = [];
    this.validateTeam();

    if (this.team.errors.length === 0) {
      if (this.team.id) {
        this.teams.updateTeam(this.team)
          .subscribe(result => {
            this.router.navigate(['/teams']);
          });
      } else {
        this.teams.saveTeam(this.team)
          .subscribe(result => {
            if(this.userService.isLoggedIn()) {
              this.router.navigate(['/teams']);
            } else {
              const ref = this.dialog.open(CodeDisplayComponent, {
                width: '400px',
                data: {
                  code: result.code
                }
              });

              ref.afterClosed().subscribe(x => {
                this.code = result.code;
              });
            }
          });
      }
    }
  }

  getErrorsForMember(index: number): string[] {
    return this.team.errors
      ? this.team.errors
        .filter(x => x.memberIndex === index)
        .map(x => x.error)
      : [];
  }

  validateTeam() {
    this.team.members.forEach((member, index, array) => {
      this.validateMember(member);
    });

    if (!this.team.name) {
      this.team.errors.push({
        memberIndex: -1,
        error: 'A name is required.'
      });
    }
  }

  validateMember(member: TeamMember) {
    const index = this.team.members.findIndex(x => x.pokemon.number === member.pokemon.number);

    if (member.natureId <= 0) {
      this.team.errors.push({
        memberIndex: index,
        error: 'A nature must be selected.'
      });
    }

    if (member.itemId <= 0) {
      this.team.errors.push({
        memberIndex: index,
        error: 'An item must be selected.'
      });
    }

    if (member.abilityId <= 0) {
      this.team.errors.push({
        memberIndex: index,
        error: 'An ability must be selected.'
      });
    }

    if (member.move1Id <= 0) {
      this.team.errors.push({
        memberIndex: index,
        error: 'Move 1 must be selected.'
      });
    }

    if (member.move2Id <= 0) {
      this.team.errors.push({
        memberIndex: index,
        error: 'Move 2 must be selected.'
      });
    }

    if (member.move3Id <= 0) {
      this.team.errors.push({
        memberIndex: index,
        error: 'Move 3 must be selected.'
      });
    }

    if (member.move4Id <= 0) {
      this.team.errors.push({
        memberIndex: index,
        error: 'Move 4 must be selected.'
      });
    }
  }

  copyCode(payload: string) {
    this.snackbar.open(
      `${payload} was copied to clipboard`,
      null,
      {
        duration: 1000,
        panelClass: 'snack'
      }
    );
  }
}
