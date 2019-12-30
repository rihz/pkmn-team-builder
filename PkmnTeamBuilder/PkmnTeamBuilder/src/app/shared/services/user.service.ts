import { BaseService } from './base.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { UserRegistration } from '../models';
import { ConfigService } from './config.service';
import { Router } from '@angular/router';

@Injectable()
export class UserService extends BaseService {
    baseUrl = '';

    private _authNavStatusSource = new BehaviorSubject<boolean>(false);
    authNavStatus$ = this._authNavStatusSource.asObservable();

    private loggedIn = false;

    constructor(private http: HttpClient, 
        private configService: ConfigService,
        private router: Router) {
        super();
        this.loggedIn = !!localStorage.getItem('auth_token');
        this._authNavStatusSource.next(this.loggedIn);
        this.baseUrl = configService.getApiURL();
    }

    register(email: string, password: string, username: string) {
        const body = JSON.stringify({ email, password, username });
        const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

        this.http.post(this.baseUrl + '/auth/signup', body, { headers: headers })
            .subscribe(result => {
                if(result) {
                    this.router.navigate(['/']);
                }
            });
    }

    login(userName, password) {
        const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

        return this.http
            .post<any>(
                this.baseUrl + '/auth/login',
                JSON.stringify({ userName, password }), { headers }
            );
    }

    logout() {
        localStorage.removeItem('auth_token');
        this.loggedIn = false;
        //this._authNavStatusSource.next(false);
    }

    isLoggedIn() {
        return !!localStorage.getItem('auth_token');
    }

    hasLoggedIn() {
        this.loggedIn = true;
        //this._authNavStatusSource.next(true);
    }

    get username() {
        const un = localStorage.getItem('username');

        return un ? un : 'User';
    }

    get email() {
        const em = localStorage.getItem('email');

        return em ? em : '';
    }

    get theme() {
        const th = localStorage.getItem('theme');

        return th? th : 'charmander';
    }
}