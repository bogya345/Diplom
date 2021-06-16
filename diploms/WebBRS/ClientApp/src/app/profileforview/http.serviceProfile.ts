import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

export class profile_HttpService {
  private url = "/prortfolio";
  private url2 = "/attedanceReason";

  constructor(private http: HttpClient) { }
  getPortfolio(Id): Observable<PortfolioVM> {
    return this.http.get<PortfolioVM>(`prortfolio/GetPortfolio/${Id}`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  getPortfolio2(Id): Observable<GroupVM[]> {
    return this.http.get<GroupVM[]>(`CuratorStatisticController/GetCharts3/${Id}/2020-09-01/2020-12-30`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  getAttedance(Id): Observable<AttedanceReason> {
    return this.http.get<AttedanceReason>(`attedanceReason/GetAttedanceReason/${Id}`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  getProfile(Id): Observable<ProfileVM> {
    return this.http.get<ProfileVM>(`prortfolio/GetPortfile/${Id}`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }


  getPortfolios(Id): Observable<PortfolioVM[]> {
    return this.http.get<PortfolioVM[]>(`prortfolio/GetPortfolios/${Id}`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  getAttedanceReason(Id): Observable<AttedanceReason[]> {
    console.log('Id in http', Id)
    return this.http.get<AttedanceReason[]>(`attedanceReason/GetAttedanceReasons/${Id}`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  postData(portfolioAdd: PortfolioVM) {
    console.log('нажали ', portfolioAdd);
    const formData = new FormData();
    // optional you can pass a file name as third parameter
    formData.append('file', portfolioAdd.File);
    formData.append('IdPortfolio', String(portfolioAdd.IdPortfolio));
    formData.append('IdPerson', String(portfolioAdd.IdPerson));
    formData.append('Description', String(portfolioAdd.Description));
    formData.append('Name', String(portfolioAdd.Name));
    formData.append('PersonFIOconfirmed', String(portfolioAdd.PersonFIOconfirmed));
    formData.append('DateAdded', String(portfolioAdd.DateAdded));
    formData.append('DateConfirmed', String(portfolioAdd.DateConfirmed));
    formData.append('Confirmed', String(portfolioAdd.Confirmed));
    //const body = { name: user.name, age: user.age };
    return this.http.post(this.url + '/UpdatePortfolioWork', formData, { observe: 'response' });
  }
  postDataReason(portfolioAdd: AttedanceReason) {
    console.log('нажали ', portfolioAdd);
    const formData = new FormData();
    // optional you can pass a file name as third parameter
    formData.append('file', portfolioAdd.File);
    formData.append('IdAttReas', String(portfolioAdd.IdAttReas));
    formData.append('IdPerson', String(portfolioAdd.IdPerson));
    formData.append('DocName', String(portfolioAdd.DocName));
    formData.append('PersonFIO', String(portfolioAdd.PersonFIO));
    //formData.append('PersonFIOconfirmed', String(portfolioAdd.PersonFIOconfirmed));
    formData.append('DateAdded', String(portfolioAdd.DateAdded));
    formData.append('DateConfirmed', String(portfolioAdd.DateConfirmed));
    //formData.append('Confirmed', String(portfolioAdd.Confirmed));
    //const body = { name: user.name, age: user.age };
    return this.http.post(this.url2 + '/UpdateAttedanceReason', formData, { observe: 'response' });
  }
}
interface ProfileVM {
  IdPerson: number,
  PersonFIO: string,
  NopeAttedanceConfirmed: number,
  NopeAttedanceProc: number,
  Group: string,
  NopeAttedance: number,
  Portfolios: PortfolioVM[];
}
interface PortfolioVM {
  IdPortfolio: number,
  IdPerson: number,
  Description: string,
  Name: string,
  FilePath: string,
  PersonFIOconfirmed: string,
  DateAdded: string,
  DateConfirmed: string,
  Confirmed: string,
  File: File
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
interface AttedanceReason {

  IdAttReas: number,
  DocName: string,
  IdPerson: number,
  IdSGH: number,
  IdCurator: number,
  PersonFIO: string,
  CuratorFIO: string,
  FilePath: string,
  DateTimeStart: string,
  DateTimeEnd: string,
  DateAdded: string,
  DateConfirmed: string,
  DateNotConfirmed: string,
  File: File
}
