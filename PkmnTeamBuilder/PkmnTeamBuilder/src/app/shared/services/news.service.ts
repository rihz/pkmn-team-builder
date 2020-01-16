import { Injectable } from "@angular/core";
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from './config.service';
import { Observable } from 'rxjs';

@Injectable()
export class NewsService extends BaseService {
    baseUrl = '';

    constructor(private http: HttpClient,
        private config: ConfigService) {
        super();

        this.baseUrl = config.getApiURL();
    }

    getNews(): Observable<Object> {
        return this.http.get(this.baseUrl + '/news/');
    }
}