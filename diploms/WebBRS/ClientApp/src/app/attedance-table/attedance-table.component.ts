import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-attedance-table',
  templateUrl: './attedance-table.component.html',
  styleUrls: ['./attedance-table.component.css']
})
export class AttedanceTableComponent implements OnInit {

  constructor() { }

  ngOnInit() {
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
