import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class homeworkListTeacher_HttpService {

  constructor(private http: HttpClient) { }

  private url = "/attedance";
  private url2 = "/homeworks";
  getTeacherClassList(IdSelectedDraft, IdSelectedDraftType, DateTimeExact): Observable<AttedanceForWork[]> {
    //return this.http.get<TimeTable2>(`timeTable/GetTimeTable/-1096224834/2007228761/2001-01-08T00:00:00`,
    return this.http.get<AttedanceForWork[]>(`homeworks/getClassWork/${IdSelectedDraft}/${IdSelectedDraftType}/${DateTimeExact}/false/false`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  getDrafts(IdSelectedDraft): Observable<DraftTimeTable[]> {
    //return this.http.get<TimeTable2>(`timeTable/GetTimeTable/-1096224834/2007228761/2001-01-08T00:00:00`,
    return this.http.get<DraftTimeTable[]>(`homeworks/GetDraftTimeTables/${IdSelectedDraft}`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  getDraftTypes(IdSelectedDraft): Observable<TypeTimeTable[]> {
    //return this.http.get<TimeTable2>(`timeTable/GetTimeTable/-1096224834/2007228761/2001-01-08T00:00:00`,
    return this.http.get<TypeTimeTable[]>(`homeworks/GetDraftTipes/${IdSelectedDraft}`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
}
interface AttedanceForWork {
  IdAtt: number,
  TextDoClassWork: string,
  PersonFIO: string,
  FilePath: string,
  BallHW: number,
  Done: string,
  DatePass: string
}

interface DraftTimeTable {
  IdDFTT: number,
  _Description: string
}
interface TypeTimeTable {
  IdDTTT: number,
  _Description: string
} 
