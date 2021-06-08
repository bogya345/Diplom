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

  getTeacherClassList(IdSelectedDraft, IdSelectedDraftType,  DateTimeStart, DateTimeEnd, ID_reff, conf): Observable<AttedanceForWork[]> {
    //return this.http.get<TimeTable2>(`timeTable/GetTimeTable/-1096224834/2007228761/2001-01-08T00:00:00`,
    return this.http.get<AttedanceForWork[]>(`homeworks/getClassWork/${IdSelectedDraft}/${IdSelectedDraftType}/${DateTimeStart}/${DateTimeEnd}/false/${conf}/${ID_reff}`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  execute(portfolioAdd: AttedanceForWork) {
    console.log('нажали ', portfolioAdd);
    //let dataToSend = { data: { 'IdPortfolio': IdPortfolio } }; 
    //console.log('нажали 2222', this.http.post(this.url + '/DeletePortfolio', IdPortfolio, { observe: 'response' }));
    //const body = { name: user.name, age: user.age };
    //return this.http.post(this.url + '/DeletePortfolio', dataToSend, { observe: 'response' });
    return this.http.post(this.url2 + '/UpdateAnswerByTeacher', portfolioAdd, { observe: 'response' });
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
  getSubjects(IdSelectedDraft): Observable<SubjectForGroup[]> {
     return this.http.get<SubjectForGroup[]>(`homeworks/GetSubjects/${IdSelectedDraft}`,
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
interface SubjectForGroup {
  IdSFG: number,
  ID_reff: number,
  IdSubject: number,
  NameSubject: string
}

interface TypeTimeTable {
  IdDTTT: number,
  _Description: string
} 
