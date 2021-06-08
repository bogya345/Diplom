import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
import { registerLocaleData } from '@angular/common';

import { Router, ActivatedRoute } from '@angular/router';
import localeRu from '@angular/common/locales/ru';
import { statistic_HttpService } from './http.curatorStatistic';
registerLocaleData(localeRu, 'ru');

@Component({
  selector: 'app-curatorstatfor-pdf',
  templateUrl: './curatorstatfor-pdf.component.html',
  styleUrls: ['./curatorstatfor-pdf.component.css']
})
export class CuratorstatforPDFComponent implements OnInit {
  public DateTimeStart: string;
  public DateTimeEnd: string;
  public DateNow: Date;
  public http: statistic_HttpService;
  public selectedGroup: number;
  public Groups: GroupVM[];
  public SelectedGroup: GroupVM;
  public baseUrl: string;
  constructor(http: HttpClient, private router: Router, private _route: ActivatedRoute, @Inject('BASE_URL') baseUrl: string) {
    this.http = new statistic_HttpService(http);
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    let IdClass = this._route.snapshot.paramMap.get('IdClass');
    let DateStart = this._route.snapshot.paramMap.get('DateStart');
    let DateEnd = this._route.snapshot.paramMap.get('DateEnd');
    this.DateTimeStart = DateStart;
    this.DateTimeEnd = DateEnd;
    this.DateNow = new Date();
    console.log("data: ", this.DateNow);
    this.http.getPortfolio(this.DateTimeStart, this.DateTimeEnd)
      .subscribe(result => {
        this.Groups = result;
        this.SelectedGroup = this.Groups[0];
        console.log('keks', this.Groups);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
    window.print();
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
