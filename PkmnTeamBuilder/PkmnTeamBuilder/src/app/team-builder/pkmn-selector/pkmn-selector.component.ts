import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { PkmnService } from '../../shared/services/pkmn.service';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'pkmn-selector',
  templateUrl: './pkmn-selector.component.html',
  styleUrls: ['./pkmn-selector.component.scss']
})
export class PkmnSelectorComponent implements OnInit {
  results: any;

  constructor(private pkmn: PkmnService,
    private ref: MatDialogRef<PkmnSelectorComponent>) { }

  ngOnInit() {

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

}
