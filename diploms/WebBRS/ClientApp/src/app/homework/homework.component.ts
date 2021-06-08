import { Component, OnInit, Inject } from '@angular/core';

import { homework_HttpService } from './http.serviceHomework';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-homework',
  templateUrl: './homework.component.html',
  styleUrls: ['./homework.component.css']
})
export class HomeworkComponent implements OnInit {
  public http: homework_HttpService;
  public baseUrl: string;
  public now: Date;
  public Url = 'https://localhost:44371/';
  public HW: ClassWork;
  public StudentAnswer: AttedanceForWork;
  public cw: HomeWorksModelView = {
    IdClassWork: 1,
    IdClass: 1,
    SubjectGroup: {
      IdSubject: 1,
      NameSubject: 'Предмет 1'
    },
    Lecturer:
    {
      IdLecturer: 1, PersonFIO: 'Лектор1',
      email: 'email@mail.test' },

    TextWork: 'Конспект выполнить',
    FilePathWork: 'files/cw/1',
    MaxBall: 6,
    MyBall: 5,
    DateTimeGiven: '25.03.21',
    DateTimeLoaded: '29.03.21',
    DateTimePassed: '01.04.21',
    Passed: 'сдал'
  };
  constructor(http: HttpClient, private router: Router, private _route: ActivatedRoute, @Inject('BASE_URL') baseUrl: string) {
    this.http = new homework_HttpService(http);
    this.baseUrl = baseUrl;
    //this.selectedGroup = { idGroup: null, GroupName: '', Specialty: '' }
  }
  selectChangeHandlerText(event: any) {
    //update the ui
    this.StudentAnswer.TextDoClassWork = event.target.value;
    console.log(this.StudentAnswer);

    //this.http.getTeacherClassList(this.TimeTable2.IdSelectedDraft, this.TimeTable2.IdSelectedDraftType, this.TimeTable2.IdDateSelected)
    //  .subscribe(result => {
    //    this.TimeTable2 = result;
    //    this.TimeTable2.Days = result.Days;
    //    console.log('keks', this.TimeTable2);
    //    console.log('result/constructor', result);
    //  }, error => {
    //    console.log('error/constructor', error);
    //  }
    //  );
  }
  onSelectFile(fileInput: any) {
    this.StudentAnswer.File = <File>fileInput.target.files[0];
    console.log('FileAdded  ', this.StudentAnswer);
  }
  postData() {

    return this.http.updateHW(this.StudentAnswer)
      .subscribe(result => {
        console.log(result);
      });
  }
  ngOnInit() {
    let IdClass = this._route.snapshot.paramMap.get('IdClass');
    this.http.getClassWorkExactClass(IdClass)
      .subscribe(result => {
        this.HW = result;
        //if (this.cw=null) {
        //  this.cw =
        //  {
        //    IdClasss: Number(IdClass),
        //    FilePathWork: '',
        //    TextWork: '',
        //    MaxBall: 0,
        //    IdClassWork: null,
        //    DatePass: Date.now() as unknown as Date
        //  }
        //}
        //this.ecflct.SelectedGroup = result.SelectedGroup;
        console.log('result/constructor2', this.HW);

      }, error => {
        console.log('error/constructor2', error);
      }
    );
    this.http.getClassWorkStudentAnswer(IdClass)
      .subscribe(result => {
        this.StudentAnswer = result;
        //if (this.cw=null) {
        //  this.cw =
        //  {
        //    IdClasss: Number(IdClass),
        //    FilePathWork: '',
        //    TextWork: '',
        //    MaxBall: 0,
        //    IdClassWork: null,
        //    DatePass: Date.now() as unknown as Date
        //  }
        //}
        //this.ecflct.SelectedGroup = result.SelectedGroup;
        console.log('result/constructorCW', this.StudentAnswer);

      }, error => {
        console.log('error/constructorCW', error);
      }
      );
  }

}
interface SubjectGroup {
  IdSubject: number,
  NameSubject: string

}
interface Lecturer {
  IdLecturer: number,
  PersonFIO: string,
  email: string

}
interface HomeWorksModelView {
  IdClassWork: number,
  IdClass: number,
  Lecturer: Lecturer,
  SubjectGroup: SubjectGroup,
  TextWork: string,
  FilePathWork: string,
  MaxBall: number,
  MyBall: number,
  DateTimeGiven: string,
  DateTimeLoaded: string,
  DateTimePassed: string,
  Passed: string
}

interface ClassWork {
  IdClassWork: number,
  IdClasss: number,
  TextWork: string,
  SubjectName: string,
  LecturerFIO: string,
  FilePathWork: string,
  MaxBall: number,
  DatePass: Date,
  DateGiven: Date
}
interface AttedanceForWork {
  IdAtt: number,
  TextDoClassWork: string,
  PersonFIO: string,
  Email: string,
  FilePath: string,
  BallHW: number,
  Done: string,
  DatePass: string,
  File: File
}
//interface Profile {
//  IdPerson: number,
//  PersonFIO: string
//}
