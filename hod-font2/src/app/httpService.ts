
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from './../environments/environment';
import { MethodCall } from '@angular/compiler';

export class app_HttpService {

    constructor(private http: HttpClient) {
    }

    protected getBaseUrl(): string { return environment.hod_api_url; }


}
