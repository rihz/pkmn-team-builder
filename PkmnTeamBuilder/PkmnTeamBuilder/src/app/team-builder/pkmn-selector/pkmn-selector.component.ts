import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { PkmnService } from '../../shared/services/pkmn.service';
import { MatDialogRef } from '@angular/material';
import { MemberService } from '../../shared/services/member.service';

@Component({
  selector: 'pkmn-selector',
  templateUrl: './pkmn-selector.component.html',
  styleUrls: ['./pkmn-selector.component.scss']
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
        console.log(x);
        this.existing = x;
      });
  }

  search(value: string) {
    this.pkmn.searchPokemon(value)
      .subscribe(x => {
        this.results = x;
      })
  }

  select(id: number) {
    this.pkmn.getPokemon(id)
      .subscribe(pokemon => {
        this.ref.close(pokemon);
      })
  }

  handleEnter() {
    this.pkmn.getPokemon(this.results[0].id)
      .subscribe(pokemon => {
        this.ref.close(pokemon);
      })
  }

}
