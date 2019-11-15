import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { PkmnService } from 'src/app/shared/services/pkmn.service';
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

  async search(value: string) {
    this.results = this.pkmn.searchPokemon(value);
  }

  async select(name: string) {
    const pokemon = await this.pkmn.getPokemon(name);
    
    this.ref.close(pokemon);
  }

}
