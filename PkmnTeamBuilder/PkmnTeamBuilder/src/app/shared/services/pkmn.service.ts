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
        
        if(this._pkmn.length <= 0) {
            this._pokedex.resource(['/api/v2/pokemon/?limit=964'])
            .then(function(response) {
                self._pkmn = response[0].results;
            });
        }
    }

    async getPokemon(name: string) {
        return await this._pokedex.getPokemonByName(name);
    }

    searchPokemon(search: string) {
        return this._pkmn.filter(pkmn => {
            if(pkmn.name.indexOf(search) > -1) {
                return true;
            }
        });
    }
}