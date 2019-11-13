import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { PkmnService } from 'src/app/shared/services/pkmn.service';

@Component({
  selector: 'gen-selector',
  templateUrl: './gen-selector.component.html',
  styleUrls: ['./gen-selector.component.scss']
})
export class GenSelectorComponent implements OnInit {
  @Output() onSelect: EventEmitter<number> = new EventEmitter<number>();
  litten: any;
  popplio: any;
  rowlet: any;

  gen: 7;

  constructor(private pkmn: PkmnService) { }

  async ngOnInit() {
    this.litten = await this.getPokemon('litten');
    this.popplio = await this.getPokemon('popplio');
    this.rowlet = await this.getPokemon('rowlet');
  }

  async getPokemon(name: string) {
    return await this.pkmn.getPokemon(name);
  }

  select() {
    this.onSelect.emit(this.gen);
  }

}
