import { Component, OnInit } from '@angular/core';
import { Item, TeamMember, Team } from '../shared/models';
import { PkmnService } from '../shared/services/pkmn.service';
import { ThemeService } from '../shared/theme/theme.service';

@Component({
  selector: 'team-builder',
  templateUrl: './team-builder.component.html',
  styleUrls: ['./team-builder.component.scss']
})
export class TeamBuilderComponent implements OnInit {
  gen = null;
  team: Team = new Team();
  items: any;
  natures: any;
  _activeTheme: string = '';

  constructor(private pkmn: PkmnService,
    private themeService: ThemeService) { }

  get activeTheme() {
    return this._activeTheme;
  }

  set activeTheme(value: string) {
    this._activeTheme = value;

    this.themeService.setTheme(value);
  }

  ngOnInit() {
    this.gen = localStorage.getItem('teamBuilderGen');

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

  removeMember(member: any) {
    this.team.members = this.team.members.filter((value, index, array) => {
      return value.pokemon.id != member.pokemon.id;
    });
  }

  changeMember(chg: any) {
    const index = this.team.members.findIndex(x => x.pokemon.id === chg.previous.pokemon.id);
    
    let teamMember = new TeamMember();
    teamMember.pokemonId = chg.next.id;
    teamMember.pokemon = chg.next;

    this.team[index] = teamMember;
  }

  save() {
    this.team.errors = [];
    this.validateTeam();
    
    if(this.team.errors.length === 0) {
      this.pkmn.saveTeam(this.team)
        .subscribe(result => {
          // show success toast
        })
    }
  }

  validateTeam() {
    this.team.members.forEach((member, index, array) => {
      this.validateMember(member);
    });

    if(!this.team.name) {
      this.team.errors.push({
        memberIndex: -1,
        error: 'A name is required.'
      });
    }
  }

  validateMember(member: TeamMember) {
    const index = this.team.members.findIndex(x => x.pokemon.number === member.pokemon.number);

    if(member.natureId <= 0) {
      this.team.errors.push({
        memberIndex: index,
        error: 'A nature must be selected.'
      });
    }

    if(member.itemId <= 0) {
      this.team.errors.push({
        memberIndex: index,
        error: 'An item must be selected.'
      });
    }

    if(member.abilityId <= 0) {
      this.team.errors.push({
        memberIndex: index,
        error: 'An ability must be selected.'
      });
    }

    if(member.move1Id <= 0) {
      this.team.errors.push({
        memberIndex: index,
        error: 'Move 1 must be selected.'
      });
    }

    if(member.move2Id <= 0) {
      this.team.errors.push({
        memberIndex: index,
        error: 'Move 2 must be selected.'
      });
    }

    if(member.move3Id <= 0) {
      this.team.errors.push({
        memberIndex: index,
        error: 'Move 3 must be selected.'
      });
    }

    if(member.move4Id <= 0) {
      this.team.errors.push({
        memberIndex: index,
        error: 'Move 4 must be selected.'
      });
    }
  }
}
