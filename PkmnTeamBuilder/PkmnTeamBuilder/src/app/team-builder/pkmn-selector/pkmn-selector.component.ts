import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { PkmnService } from '../../shared/services/pkmn.service';
import { MatDialogRef } from '@angular/material';
import { MemberService } from '../../shared/services/member.service';
import { TeamMember, Move, Pokemon } from '../../shared/models';

@Component({
  selector: 'pkmn-selector',
  templateUrl: './pkmn-selector.component.html',
  styleUrls: ['./pkmn-selector.component.scss'],
  providers: [MemberService]
})
export class PkmnSelectorComponent implements OnInit {
  results: any;
  existing: any;

  constructor(private pkmn: PkmnService,
    private members: MemberService,
    private ref: MatDialogRef<PkmnSelectorComponent>) { }

  ngOnInit() {
    const userId = localStorage.getItem('userId');

    this.members.getMembers(userId)
      .subscribe(x => {
        this.existing = x;
      });
  }

  search(value: string) {
    this.pkmn.searchPokemon(value)
      .subscribe(x => {
        this.results = x;
      });
  }

  select(id: number) {
    this.pkmn.getPokemon(id)
      .subscribe(pokemon => {
        this.ref.close({
          result: 'pokemon',
          payload: pokemon
        });
      });
  }

  selectMember(member: TeamMember) {
    this.pkmn.getPokemon(member.pokemonId)
      .subscribe(pokemon => {
        member.pokemon = <Pokemon>pokemon;

        this.ref.close({
          result: 'member',
          payload: member
        });
      });
  }

  handleEnter() {
    this.pkmn.getPokemon(this.results[0].id)
      .subscribe(pokemon => {
        this.ref.close(pokemon);
      })
  }

  getIVs(member: TeamMember): string {
    return `${member.hpIV} | ${member.atkIV} | ${member.defIV} | ${member.spatkIV} | ${member.spdefIV} | ${member.speIV}`;
  }

  getEVs(member: TeamMember): string {
    return `${member.hpEV} | ${member.atkEV} | ${member.defEV} | ${member.spatkEV} | ${member.spdefEV} | ${member.speEV}`;
  }

  getNatureTooltip(member: TeamMember): string {
    return `${member.nature.increase} is increased | ${member.nature.decrease} is decreased`;
  }

  getMoveTooltip(move: Move): string {
    return `${move.categoryName.toUpperCase()}\n${move.description}`;
  }

}
