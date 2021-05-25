//import { Chart } from 'chart.js';
import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { statistic_HttpService } from './http.serviceStatistic';
//import { Data } from '../../app/Data';  
@Component({
  selector: 'app-curator-statistic',
  templateUrl: './curator-statistic.component.html',
  styleUrls: ['./curator-statistic.component.css']
})
export class CuratorStatisticComponent   {
  public DateTimeStart: string;
  public DateTimeEnd: string;
  public http: statistic_HttpService;
  public selectedGroup: number;
  public Groups: GroupVM[];
  public SelectedGroup: GroupVM;
  public baseUrl: string;

  selectChangeHandler6(event: any) {

    this.DateTimeStart = event.target.value;
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
    console.log(event.target.value);
  }
  selectChangeHandler7(event: any) {

    this.DateTimeEnd = event.target.value;
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
    //this.http.getPortfolios(this.conf, this.DateTimeStart, this.DateTimeEnd)
    //  .subscribe(result => {
    //    this.portfolios = result;

    //    console.log('portfolios', this.portfolios);
    //    console.log('result/constructor', result);

    //  }, error => {
    //    console.log('error/constructor', error);
    //  }
    //  );

    console.log(event.target.value);
  }
  constructor(http: HttpClient, private router: Router, private _route: ActivatedRoute, @Inject('BASE_URL') baseUrl: string) {
    this.http = new statistic_HttpService(http);
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
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
  
  }
}

interface GroupVM {
  idGroup:number,
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
interface SubjectGroup{
  IdSubject: number,
  SubjectName: string
}
interface AttedancedVMType {

  attedanced: string,
  Ball: string,
  BallHW: string
}
