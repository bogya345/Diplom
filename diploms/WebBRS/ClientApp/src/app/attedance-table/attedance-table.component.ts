import { Component, OnInit, Inject } from '@angular/core';

import { attedanceTable_HttpService } from './http.serviceAttedanceTable';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
//import moment = require('moment');
@Component({
  selector: 'app-attedance-table',
  templateUrl: './attedance-table.component.html',
  styleUrls: ['./attedance-table.component.css']
})
//export class SelectOverviewExample {
//  foods: GroupAttedanceTable[] = [
//    { value: 'steak-0', viewValue: 'Steak' },
//    { value: 'pizza-1', viewValue: 'Pizza' },
//    { value: 'tacos-2', viewValue: 'Tacos' }
//  ];
//}
export class AttedanceTableComponent implements OnInit {
  public http: attedanceTable_HttpService;
  public baseUrl: string;
  public ecflct: ExactClassForLecturerClassTable;
  public selectedGroup: GroupAttedanceTable;
  public now: Date;
  //public onOptionsSelected(event) {
  //  const value = event.target.value;
  //  this.selectedGroup = value;
  //  console.log(value);
  //}

  
  selectChangeHandler(event: any) {
    //update the ui
    this.selectedGroup.idGroup = event.target.value;
    console.log(this.selectedGroup.idGroup);
    this.http.getAttedanceForLecturerClasses(this.ecflct.IdECFLCT, this.selectedGroup.idGroup)
      .subscribe(result => {
        this.ecflct = result;

        this.ecflct.SubjectName = result.SubjectName;

        this.ecflct.Groups = result.Groups;
        this.ecflct.Students = result.Students;
        console.log('keks', this.ecflct.Groups);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }
  //public http: personList_HttpService;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string ) {
    this.http = new attedanceTable_HttpService(http);
    this.baseUrl = baseUrl;
    this.selectedGroup = { idGroup: 1739436558, GroupName: '', Specialty: ''}
  }

  ngOnInit() {
    this.http.getAttedanceForLecturerClasses(-1194773169, this.selectedGroup.idGroup)
      .subscribe(result => {
        this.ecflct = result;

        this.ecflct.SubjectName = result.SubjectName;

        this.ecflct.Groups = result.Groups;
        this.ecflct.Students = result.Students;
        this.ecflct.IdECFLCT = result.IdECFLCT;
        console.log('keks', this.ecflct.Groups);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );

  }
  



}

interface GroupAttedanceTable {
  idGroup: number,
  GroupName: string,
  Specialty: string
}
export interface  ExactClassForLecturerClassTable {
  IdECFLCT: number;
  Lecturer: Lecturer2;
  ExactClasses: ExactClass[];
  Groups: GroupAttedanceTable[];
  Students: StudentTable[];
  SubjectName: string;
  IdSFG: number;
  SelectedGroup: number;
}
interface StudentTable {
  IdStudent: number,
  PersonFIO: string,
  Attedanced: string[]
}
interface Lecturer2 {
  IdLecturer: number,
  PersonFIO: string

}

interface ExactClass {
  IdClass: number,
  DateExactClass: string,
  numberClass: number,
  //Group: GroupAttedanceTable
}
