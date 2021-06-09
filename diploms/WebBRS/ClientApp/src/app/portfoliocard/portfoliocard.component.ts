import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-portfoliocard',
  templateUrl: './portfoliocard.component.html',
  styleUrls: ['./portfoliocard.component.css']
})
export class PortfoliocardComponent implements OnInit {
  public profiles: ProfileVM[];
  constructor(private http: HttpClient) {
    this.getProfile()
      .subscribe(result => {
        this.profiles = result;

        console.log('portfolios', this.profiles);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }
  getProfile(): Observable<ProfileVM[]> {
    return this.http.get<ProfileVM[]>(`CuratorStatisticController/GetPortfolioCards`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  ngOnInit() {
    this.getProfile()
      .subscribe(result => {
        this.profiles = result;

        console.log('portfolios', this.profiles);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }

}
interface ProfileVM {
  IdPerson: number,
  PersonFIO: string,
  NopeAttedanceConfirmed: number,
  NopeAttedanceProc: number,
  NopeAttedance: number,
  Group: string,
  Telephone: string,
  Rabota: string
}
