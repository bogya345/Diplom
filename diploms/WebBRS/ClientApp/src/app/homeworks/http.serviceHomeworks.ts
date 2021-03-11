import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

export class homeworks_HttpService {

  constructor(private http: HttpClient) { }
  getClassWorksList(): Observable<ClassWork[]> {
    return this.http.get<ClassWork[]>(`homeworks/getall`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }

}
interface ClassWork {
  IdClassWork: number,
  IdClass: number,
  TextWork: string,
  MaxBall: number
}
