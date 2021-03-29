import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

export class attedance_HttpService {

  constructor(private http: HttpClient) { }
  getAttedanceForLecturerClasses(): Observable<ExactClassForLecturerClass> {
    return this.http.get<ExactClassForLecturerClass>(`attedance/getAttdance/1/2/1`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  getAttedanceExactClass(): Observable<ExactClass> {
    return this.http.get<ExactClass>(`attedance/getExactClass/1/2/1`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
}
