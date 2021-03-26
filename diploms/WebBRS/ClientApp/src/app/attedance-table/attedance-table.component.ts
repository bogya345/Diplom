import { Component, OnInit, Inject } from '@angular/core';

import { attedanceTable_HttpService } from './http.serviceAttedanceTable';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
@Component({
  selector: 'app-attedance-table',
  templateUrl: './attedance-table.component.html',
  styleUrls: ['./attedance-table.component.css']
})
export class AttedanceTableComponent implements OnInit {
  public http: attedanceTable_HttpService;

  public groups: Group[];
  public students: Student[];
  public lecturer: Lecturer;
  public exactClassForLecturerClass: ExactClassForLecturerClass;
  constructor() { }

  ngOnInit() {
    this.http.getAttedanceForLecturerClasses()
      .subscribe(result => {
        this.exactClassForLecturerClass = result;
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }



}
interface Group {
  idGroup: number,
  GroupName: string,
  Specialty: string,
  Students: Student[]
}
interface ExactClassForLecturerClass {
  Groups: Group[],
  Lecturer: Lecturer,
  ExactClasses: ExactClass[],
  Students: Student[]
}
interface Student {
  IdStudent: number,
  PesonFIO: string,
  Attedanced: string[]
}
interface Lecturer {
  IdStudent: number,
  PesonFIO: string

}

interface ExactClass {
  IdClass: number,
  DateExactClass: Date,
  numberClass: number
}
