import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

export class profile_HttpService {
  private url = "/prortfolio";

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
  execute(portfolioId: number) {
    console.log('нажали ', portfolioId);
    //const body = { name: user.name, age: user.age };
    return this.http.post(this.url + '/DeletePortfolio', portfolioId, { observe: 'response' });
  }
  getPortfolios(): Observable<PortfolioVM[]> {
    return this.http.get<PortfolioVM[]>(`prortfolio/GetPortfolios`,
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
    return this.http.post(this.url +'/UpdatePortfolioWork', portfolioAdd, { observe: 'response' });
  }
}
interface ProfileVM {
  IdPerson: number,
  PersonFIO: string,
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
  Confirmed: string

}
