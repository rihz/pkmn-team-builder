import { Injectable } from "@angular/core";
import { BaseService } from './base.service';
import { HttpClient } from "@angular/common/http";
import { ConfigService } from "./config.service";
import { Observable } from "rxjs";

@Injectable()
export class PkmnService extends BaseService {
    baseUrl = '';

    constructor(private http: HttpClient,
        private configService: ConfigService) {
        super();
        this.baseUrl = configService.getApiURL();
    }

    getPokemon(id: number): Observable<Object> {
        return this.http.get(this.baseUrl + '/pokemon/' + id)
    }

    searchPokemon(search: string) {
        return this.http.get(this.baseUrl + '/pokemon?name=' + search)
    }

    getItems() {
        return this.http.get(this.baseUrl + '/item/');
    }
}