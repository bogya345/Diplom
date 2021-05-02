import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-homework',
  templateUrl: './homework.component.html',
  styleUrls: ['./homework.component.css']
})
export class HomeworkComponent implements OnInit {
  
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
  constructor() { }

  ngOnInit() {
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
