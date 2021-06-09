import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

export class attedanceTable_HttpService {

  constructor(private http: HttpClient) { }
  getAttedanceForLecturerClasses(ID_reff, group_id): Observable<ExactClassForLecturerClass> {
    return this.http.get<ExactClassForLecturerClass>(`attedance/GetAttedanceTable/${ID_reff}/${group_id}/true`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  //getBlockNums(acPl_id, group_id): Observable<BlockNum[]> {
  //  return this.http.get<BlockNum[]>(`${environment.hod_api_url}acplans/get/${acPl_id}/${group_id}`,
  //    {
  //      // headers: {
  //      // 'Accept': 'application/json',
  //      // 'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
  //      // }
  //    });
  //}
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
  IdECFLCT: number,
  Lecturer: Lecturer,
  LecturerFIO: string,
  ExactClasses: ExactClass[],
  Groups: Group[],
  Students: Student[],
  SubjectName: string,
  Date: string,
  SelectedGroup: number,
  IdSFG: number
}
interface Student {
  IdStudent: number,
  PersonFIO: string,
  Balls: number,
  Attedanced: AttedancedVMType[]
}
interface Lecturer {
  IdLecturer: number,
  PersonFIO: string

}

interface ExactClass {
  IdClass: number,
  DateExactClass: string,
  numberClass: number,
  Theme: string,
  ThemeShort: string
}
interface AttedanceTableRow {
  id: number,
  Student: Student,
  DateTimeReg: Date,
  BirthDate: Date
}
interface AttedancedVMType {
  Type: string,
  attedanced: string,
  Ball: string,
  BallHW: string
}
