import { Injectable } from "@angular/core";
import { BaseService } from './base.service';
import { HttpClient } from "@angular/common/http";
import { ConfigService } from "./config.service";
import { Observable } from "rxjs";
import { Team } from "../models";

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

    getNatures() {
        return this.http.get(this.baseUrl + '/nature/');
    }

    saveTeam(team: Team) {
        const userId = localStorage.getItem('userId');

        team.userId = userId;

        team.members.forEach((value, index, array) => {
            value.userId = userId;
        });

        return this.http.post(this.baseUrl + '/team/', team);
    }

    getTeams(userId: string) {
        return this.http.get(this.baseUrl + `/team?userId=${userId}`);
    }

    deleteTeam(id: number) {
        return this.http.delete(this.baseUrl + `/team/${id}`);
    }
}