import { Injectable } from "@angular/core";
import { BaseService } from './base.service';

const Pokedex = require('pokeapi-js-wrapper');

@Injectable()
export class PkmnService extends BaseService {
    _pokedex;

    constructor() {
        super();
        this._pokedex = new Pokedex.Pokedex();
    }

    async getPokemon(name: string) {
        return await this._pokedex.getPokemonByName(name);
    }
}