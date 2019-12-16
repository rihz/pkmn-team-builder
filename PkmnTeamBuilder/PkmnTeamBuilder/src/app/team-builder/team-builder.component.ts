import { Component, OnInit } from '@angular/core';
import { Item } from '../shared/models';
import { PkmnService } from '../shared/services/pkmn.service';

@Component({
  selector: 'team-builder',
  templateUrl: './team-builder.component.html',
  styleUrls: ['./team-builder.component.scss']
})
export class TeamBuilderComponent implements OnInit {
  gen = null;
  team: any[] = [];
  items: any;

  constructor(private pkmn: PkmnService) { }

  ngOnInit() {
    this.gen = localStorage.getItem('teamBuilderGen');

    this.pkmn.getItems()
      .subscribe(x => {
        this.items = x;
      })
  }

  setGen(gen: number) {
    this.gen = gen;
    
    localStorage.setItem('teamBuilderGen', gen.toString());
  }

  addPokemon(pokemon: any) {
    this.team.push(pokemon);
  }

}
