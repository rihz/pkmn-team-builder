import { Injectable } from "@angular/core";
import { BaseService } from './base.service';
import { HttpClient } from "@angular/common/http";
import { ConfigService } from "./config.service";

const Pokedex = require('pokeapi-js-wrapper');

@Injectable()
export class PkmnService extends BaseService {
    baseUrl = '';

    constructor(private http: HttpClient,
        private configService: ConfigService) {
        super();
        this.baseUrl = configService.getApiURL();
    }

    getPokemon(id: number) {
        this.http.get(this.baseUrl + '/pokemon/' + id)
            .subscribe(result => {
                console.log(result);
            });
    }

    searchPokemon(search: string) {
        this.http.get(this.baseUrl + '/pokemon?name=' + search)
            .subscribe(result => {
                console.log(result);
            });
    }
}