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
interface ExactClassForLecturerClass {
  nCode: number,
  GuidPerson: string,
  //dateCreated: Date,
  //dateEnd: Date
  FirstName: string,
  LastName: string,
  PatronicName: string,
  Email: string,
  DateTimeReg: Date,
  BirthDate: Date
}
