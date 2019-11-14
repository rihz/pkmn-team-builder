import { Component, OnInit } from '@angular/core';
import { PkmnService } from 'src/app/shared/services/pkmn.service';

@Component({
  selector: 'pkmn-selector',
  templateUrl: './pkmn-selector.component.html',
  styleUrls: ['./pkmn-selector.component.scss']
})
export class PkmnSelectorComponent implements OnInit {
  result: any;

  constructor(private pkmn: PkmnService) { }

  ngOnInit() {
  }

  async search(value: string) {
    console.log(value);
    this.result = await this.pkmn.getPokemon(value);
    console.log(this.result);
  }

}
