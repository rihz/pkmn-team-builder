import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { PkmnService } from 'src/app/shared/services/pkmn.service';

@Component({
  selector: 'gen-selector',
  templateUrl: './gen-selector.component.html',
  styleUrls: ['./gen-selector.component.scss']
})
export class GenSelectorComponent implements OnInit {
  @Output() onSelect: EventEmitter<number> = new EventEmitter<number>();

  gen: number = 7;

  constructor(private pkmn: PkmnService) { }

  ngOnInit() {
    
  }

  // async getPokemon(name: string) {
  //   return await this.pkmn.getPokemon(name);
  // }

  // select() {
  //   this.onSelect.emit(this.gen);
  // }

}
