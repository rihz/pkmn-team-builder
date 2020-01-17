import { Injectable } from "@angular/core";
import { BaseService } from "./base.service";
import { HttpClient } from "@angular/common/http";
import { ConfigService } from "./config.service";
import { Team } from "../models";
import { Observable } from 'rxjs';

@Injectable()
export class TeamService extends BaseService {
    baseUrl = '';

    constructor(
        private http: HttpClient,
        private config: ConfigService) {
        super();

        this.baseUrl = config.getApiURL();
    }

    public saveTeam(team: Team): Observable<any> {
        const userId = localStorage.getItem('userId');

        team.userId = userId;

        team.members.forEach((value, index, array) => {
            value.userId = userId;
        });

        return this.http.post(this.baseUrl + '/team/', team);
    }

    public updateTeam(team: Team) {
        const userId = localStorage.getItem('userId');

        team.userId = userId;

        team.members.forEach((value, index, array) => {
            value.userId = userId;
        });
        
        return this.http.put(this.baseUrl + `/team/`, team);
    }

    public getTeams(userId: string) {
        return this.http.get(this.baseUrl + `/team?userId=${userId}`);
    }

    public getTeam(code: string) {
        return this.http.get(this.baseUrl + `/team/code/${code}`);
    }

    public deleteTeam(id: number) {
        return this.http.delete(this.baseUrl + `/team/${id}`);
    }
}