import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

export class statistic_HttpService {
  private url = "/prortfolio";
  private url2 = "/attedanceReason";

  constructor(private http: HttpClient) { }
  getPortfolio(dateTimeStart, dateTimeEnd): Observable<GroupVM[]> {
    return this.http.get<GroupVM[]>(`CuratorStatisticController/GetCharts/${dateTimeStart}/${dateTimeEnd}`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  //getProfile(): Observable<ProfileVM> {
  //  return this.http.get<ProfileVM>(`prortfolio/GetPortfile`,
  //    {
  //      //headers: {
  //      //  'Accept': 'application/json',
  //      //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
  //      //}
  //    });
  //}

  execute(portfolioAdd: GroupVM) {
    console.log('нажали ', portfolioAdd);
    //let dataToSend = { data: { 'IdPortfolio': IdPortfolio } }; 
    //console.log('нажали 2222', this.http.post(this.url + '/DeletePortfolio', IdPortfolio, { observe: 'response' }));
    //const body = { name: user.name, age: user.age };
    //return this.http.post(this.url + '/DeletePortfolio', dataToSend, { observe: 'response' });
    return this.http.post(this.url + '/UpdatePortfolioWork', portfolioAdd, { observe: 'response' });
  }



  postData(portfolioAdd: GroupVM) {
    console.log('нажали ', portfolioAdd);
    //const body = { name: user.name, age: user.age };
    return this.http.post(this.url + '/UpdatePortfolioWork', portfolioAdd, { observe: 'response' });
  }
}
interface GroupVM {
  idGroup: number,
  GroupName: string,
  studentVMs: Student[],
  SubjectVMs: SubjectGroup[]
}
interface Student {
  IdStudent: number,
  PersonFIO: string,
  Balls: number,
  Attedanced: AttedancedVMType[]
}
interface SubjectGroup {
  IdSubject: number,
  SubjectName: string
}
interface AttedancedVMType {

  attedanced: string,
  Ball: string,
  BallHW: string
}
