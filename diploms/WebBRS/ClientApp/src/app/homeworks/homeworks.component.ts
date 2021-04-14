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
  //public classwork: ClassWork[];
  public currentCount = 0;
  public Semestrs: Array<Semestr> = [
    {
      IdSemestr: 1,
      NameSemestr: 'Первый семестр'
    },
    {
      IdSemestr: 2,
      NameSemestr: 'Второй семестр'
    }
  ];
  public Subjects: Array<SubjectGroup> = [
    {
      IdSubject: 1,
      NameSubject: 'Предмет 1'
    },
    {
      IdSubject: 2,
      NameSubject: 'Предмет 2'
    }
  ];

  public ClassWorks: Array<ClassWork> = [
    {
      IdClassWork: 1,
      IdClass: 4,
      Lecturer: { IdLecturer: 1, PersonFIO: 'Лектор1'},
      TextWork: 'Текст задания',
      MyBall: 4,
      MaxBall: 6,
      DateTimeGiven: '25.03.21',
      DateTimePassed: '25.03.21',
      Passed: 'сдал'
    }, {
      IdClassWork: 2,
      IdClass: 4,
      Lecturer: { IdLecturer: 2, PersonFIO: 'Лектор2'},
      TextWork: 'Текст задания',
      MyBall: 4,
      MaxBall: 6,
      DateTimeGiven: '25.03.21',
      DateTimePassed: '25.03.21',
      Passed: 'сдал'
    }, {
      IdClassWork: 3,
      IdClass: 4,
      Lecturer: { IdLecturer: 3, PersonFIO: 'Лектор3'},
      TextWork: 'Текст задания',
      MyBall: 4,
      MaxBall: 6,
      DateTimeGiven: '25.03.21',
      DateTimePassed: '25.03.21',
      Passed: 'сдал'
    }
  ];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = new homeworks_HttpService(http);
    this.baseUrl = baseUrl;



  }

  ngOnInit() {
    //this.http.getClassWorksList()
    //  .subscribe(result => {
    //    this.classwork = result;
    //    console.log('result/constructor', result);

    //  }, error => {
    //    console.log('error/constructor', error);
    //  }
    //  );

  }
}
interface ExactClass {
  IdClass: number,
  DateExactClass: string,
  numberClass: number
}
interface Lecturer {
  IdLecturer: number,
  PersonFIO: string

}
interface Semestr {
  IdSemestr: number,
  NameSemestr: string

}
interface SubjectGroup {
  IdSubject: number,
  NameSubject: string

}

interface ClassWork {
  IdClassWork: number,
  IdClass: number,
  Lecturer: Lecturer,
  TextWork: string,
  MaxBall: number,
  MyBall: number,
  DateTimeGiven: string,
  DateTimePassed: string,
  Passed: string
}
