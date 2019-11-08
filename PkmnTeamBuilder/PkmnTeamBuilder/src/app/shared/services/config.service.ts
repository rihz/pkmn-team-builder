import { Injectable } from '@angular/core';

@Injectable()
export class ConfigService {
    _apiURL: string;

    constructor() {
        this._apiURL = 'http://localhost:5000/api';
    }

    getApiURL() {
        return this._apiURL;
    }
}