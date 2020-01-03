import { Injectable } from "@angular/core";
import { BaseService } from "./base.service";
import { HttpClient } from "@angular/common/http";
import { ConfigService } from "./config.service";

@Injectable()
export class MemberService extends BaseService {
    baseUrl = '';

    constructor(
        private http: HttpClient,
        private config: ConfigService) {
        super();

        this.baseUrl = config.getApiURL();
    }

    getMembers(id: string) {
        return this.http.get(this.baseUrl + `/member/user/${id}`);
    }

    getMember(id: number) {
        return this.http.get(this.baseUrl + `/member/${id}`)
    }
}