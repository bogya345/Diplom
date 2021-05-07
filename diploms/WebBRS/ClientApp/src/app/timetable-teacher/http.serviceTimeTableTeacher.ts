import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

export class serviceTimeTableTeacher {

  constructor(private http: HttpClient) { }
  getTeacherClassList(): Observable<TimeTable2> {
    return this.http.get<TimeTable2>(`timeTable/GetTimeTable/-1096224834/2007228761/2001-01-08T00:00:00`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }

}
interface SubjectVM {
  //sfgs: SubjectForGroup[];
  IdSubject: number,
  SubjectName: string
}
interface TeacherClass {
  IdSFG: number,
  IdSubject: number,
  IdPerson: number,
  IdCourse: number,
  PersonFIO: number,
  StudyYearIdStudyYear: number
}
interface TimeTable {
  StudyYears: StudyYear[],
  selectedSY: StudyYear,
  SubjectVMs: SubjectVM[];
  idLect: number,
  LecturerFIO: string
}
interface StudyYear {
  IdStudyYear: number,
  _Description: string,
  DateTimeStart: string,
  DateTimeEnd: string
}
interface SubjectForGroup {

  IdSFG: number,
  IdGroup: number,
  IdCourse: number,
  DepartmentID: number,
  TypeStudy: TypeStudy
}
interface TypeStudy {
  IdTS: number,
  TypeStudyName: string,
  ShortTypeStudyName: string
}
interface EXTCforTimeTable {
  Auditory:string,
  IdECFLCT: number,
  SubjectName: string,
  DateTime: string,
  DayOfWeek: string
}

interface SubjectVM {
  //public List<SubjectForGroup> sfgs = new List<SubjectForGroup>();
  IdSubject: number,
  SubjectName: string
}
interface DraftTimeTable {
  IdDFTT: number,
  _Description: string
}
interface TypeTimeTable {
  IdDTTT: number,
  _Description: string
}
interface TimeTable2 {
  Drafts: DraftTimeTable[],
  IdSelectedDraft: number,
  DraftTypes: TypeTimeTable[],
  IdSelectedDraftType: number,
  Days: Day[]

}
interface Day {
  DayOfWeek: string,
  EXTCforTimeTables: EXTCforTimeTable[];
}

