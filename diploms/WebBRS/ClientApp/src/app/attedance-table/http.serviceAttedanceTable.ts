import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

export class attedanceTable_HttpService {

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
interface Group {
  idGroup: number,
  GroupName: string,
  Specialty: string,
  Students: Student[]
}
interface ExactClassForLecturerClass {
  Groups: Group[],
  Lecturer: Lecturer,
  ExactClasses: ExactClass[],
  Students: Student[]
}
interface Student {
  IdStudent: number,
  PesonFIO: string,
  Attedanced: string[]
}
interface Lecturer {
  IdStudent: number,
  PesonFIO: string

}

interface ExactClass {
  IdClass: number,
  DateExactClass: Date,
  numberClass: number
}
interface AttedanceTableRow {
  id: number,
  Student: Student,
  DateTimeReg: Date,
  BirthDate: Date
}
