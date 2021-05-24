import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

export class confirmedList_HttpService {
  private url = "/prortfolio";
  private url2 = "/attedanceReason";

  constructor(private http: HttpClient) { }
  getPortfolio(IdECFLCT): Observable<PortfolioVM> {
    return this.http.get<PortfolioVM>(`prortfolio/GetPortfolio/${IdECFLCT}`,
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

  execute(portfolioAdd: PortfolioVM) {
    console.log('нажали ', portfolioAdd);
    //let dataToSend = { data: { 'IdPortfolio': IdPortfolio } }; 
    //console.log('нажали 2222', this.http.post(this.url + '/DeletePortfolio', IdPortfolio, { observe: 'response' }));
    //const body = { name: user.name, age: user.age };
    //return this.http.post(this.url + '/DeletePortfolio', dataToSend, { observe: 'response' });
    return this.http.post(this.url + '/UpdatePortfolioWork', portfolioAdd, { observe: 'response' });
  }
  execute2(portfolioAdd: AttedanceReason) {
    console.log('нажали ', portfolioAdd);
    //let dataToSend = { data: { 'IdPortfolio': IdPortfolio } }; 
    //console.log('нажали 2222', this.http.post(this.url + '/DeletePortfolio', IdPortfolio, { observe: 'response' }));
    //const body = { name: user.name, age: user.age };
    //return this.http.post(this.url + '/DeletePortfolio', dataToSend, { observe: 'response' });
    return this.http.post(this.url2 + '/UpdateAttedanceReason', portfolioAdd, { observe: 'response' });
  }
  getPortfolios(conf: boolean,  DateTimeStart, DateTimeEnd): Observable<PortfolioVM[]> {
    return this.http.get<PortfolioVM[]>(`prortfolio/GetPortfoliosForConfirm/${conf}/${DateTimeStart}/${DateTimeEnd}`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  getAttedanceReasons(conf: boolean, DateTimeStart, DateTimeEnd): Observable<AttedanceReason[]> {
    return this.http.get<AttedanceReason[]>(`attedanceReason/GetAttedanceForConfirm/${conf}/${DateTimeStart}/${DateTimeEnd}`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  postData(portfolioAdd: PortfolioVM) {
    console.log('нажали ', portfolioAdd);
    //const body = { name: user.name, age: user.age };
    return this.http.post(this.url + '/UpdatePortfolioWork', portfolioAdd, { observe: 'response' });
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
  IdCourator: number,
  PersonFIO: string,
  Name: string,
  FilePath: string,
  PersonFIOconfirmed: string,
  DateAdded: string,
  DateConfirmed: string,
  DateNotConfirmed: string,
  Confirmed: string

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
  Confirmed: string
}
