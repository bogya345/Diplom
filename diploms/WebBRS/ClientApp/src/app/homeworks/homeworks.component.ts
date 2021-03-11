import { Component, OnInit, Inject } from '@angular/core';

import { Router } from '@angular/router';

import { homeworks_HttpService } from './http.serviceHomeworks';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
@Component({
  selector: 'app-homeworks',
  templateUrl: './homeworks.component.html',
  styleUrls: ['./homeworks.component.css']
})
export class HomeworksComponent implements OnInit {

  public http: homeworks_HttpService;
  public baseUrl: string;
  public classwork: ClassWork[];
  public currentCount = 0;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = new homeworks_HttpService(http);
    this.baseUrl = baseUrl;



  }

  ngOnInit() {
    this.http.getClassWorksList()
      .subscribe(result => {
        this.classwork = result;
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );

  }
}

interface ClassWork {
  IdClassWork: number,
  IdClass: number,
  TextWork: string,
  MaxBall: number
}
