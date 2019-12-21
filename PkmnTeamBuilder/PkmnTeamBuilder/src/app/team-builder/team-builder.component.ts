import { Component, OnInit } from '@angular/core';
import { Item, TeamMember } from '../shared/models';
import { PkmnService } from '../shared/services/pkmn.service';
import { ThemeService } from '../shared/theme/theme.service';

@Component({
  selector: 'team-builder',
  templateUrl: './team-builder.component.html',
  styleUrls: ['./team-builder.component.scss']
})
export class TeamBuilderComponent implements OnInit {
  gen = null;
  team: TeamMember[] = [];
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

    this.team.push(teamMember);
  }

  removeMember(member: any) {
    this.team = this.team.filter((value, index, array) => {
      return value.pokemon.id != member.pokemon.id;
    });
  }

  changeMember(chg: any) {
    const index = this.team.findIndex(x => x.pokemon.id === chg.previous.pokemon.id);
    
    let teamMember = new TeamMember();
    teamMember.pokemonId = chg.next.id;
    teamMember.pokemon = chg.next;

    this.team[index] = teamMember;
  }
}
