import { Injectable } from '@angular/core';

@Injectable()
export class ConfigService {
    _apiURL: string;
    _baseURL: string;

    constructor() {
        this._apiURL = 'http://localhost:5000/api';
        this._baseURL = 'http://localhost:4200';
    }

    getApiURL() {
        return this._apiURL;
    }

    getBaseURL() {
        return this._baseURL;
    }
}