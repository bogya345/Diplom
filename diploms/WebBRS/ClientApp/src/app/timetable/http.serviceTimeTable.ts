import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

export class serviceTimeTable {

  constructor(private http: HttpClient) { }
  getTeacherClassList(): Observable<TeacherClass[]> {
    return this.http.get<TeacherClass[]>(`homeworks/getall`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }

}
interface TeacherClass {
  IdSFG: number,
  IdSubject: number,
  IdPerson: number,
  IdCourse: number,
  PersonFIO: number,
  StudyYearIdStudyYear: number
}
