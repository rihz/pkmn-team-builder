import { Injectable } from "@angular/core";
import { BaseService } from './base.service';

const Pokedex = require('pokeapi-js-wrapper');

@Injectable()
export class PkmnService extends BaseService {
    _pokedex;
    _pkmn: any[] = [];

    constructor() {
        super();
        const self = this;
        this._pokedex = new Pokedex.Pokedex();
        
        if(this._pkmn) {
            this._pokedex.resource(['/api/v2/pokemon/?limit=964'])
            .then(function(response) {
                self._pkmn = response;
                console.log(self._pkmn);
            });
        }
    }

    async getPokemon(name: string) {
        return await this._pokedex.getPokemonByName();
    }

    searchPokemon(value: string) {
        
    }
}