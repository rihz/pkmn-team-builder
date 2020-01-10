import { Component, OnInit, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';
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
  @ViewChild('newInput', null) newInput: ElementRef;

  constructor(private pkmn: PkmnService,
    private members: MemberService,
    private ref: MatDialogRef<PkmnSelectorComponent>) { }

  ngOnInit() {
    const userId = localStorage.getItem('userId');

    this.members.getMembers(userId)
      .subscribe(x => {
        this.existing = x;
        
        setTimeout(() => {
          this.newInput.nativeElement.focus();
        }, 250);
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
    console.log(this.results[0]);
    this.pkmn.getPokemon(this.results[0].id)
      .subscribe(pokemon => {
        this.ref.close({
          result: 'pokemon',
          payload: pokemon
        });
      });
  }  

  changeTab(e: any) {
    this.newInput.nativeElement.focus();
  }

}
