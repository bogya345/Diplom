import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class sidebar_HttpService {

  constructor(private http: HttpClient) { }

  private url = "/attedance";
  private url2 = "/homeworks";

  getProfile(): Observable<Profile> {
    //return this.http.get<TimeTable2>(`timeTable/GetTimeTable/-1096224834/2007228761/2001-01-08T00:00:00`,
    return this.http.get<Profile>(`prortfolio/GetPortfile`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }

}

interface Profile {
  IdPerson: number,
  PersonFIO: string
}
