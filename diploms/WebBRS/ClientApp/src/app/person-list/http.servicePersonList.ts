import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

export class personList_HttpService {

  constructor(private http: HttpClient) { }
  getPersonList(): Observable<Person[]> {
    return this.http.get<Person[]>(`person/getall`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }

}
interface Person {
  nCode: number,
  GuidPerson: string,
  //dateCreated: Date,
  //dateEnd: Date
  FirstName: string,
  LastName: string,
  PatronicName: string,
  Email: string,
  DateTimeReg: Date,
  BirthDate: Date
}
