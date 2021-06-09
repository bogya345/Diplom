import { Component, OnInit, Inject } from '@angular/core';

import { attedanceTable_HttpService } from './http.serviceAttedance';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-attedancetableforpdf',
  templateUrl: './attedancetableforpdf.component.html',
  styleUrls: ['./attedancetableforpdf.component.css']
})
export class AttedancetableforpdfComponent implements OnInit {

  public http: attedanceTable_HttpService;
  public baseUrl: string;
  public Url = 'https://localhost:44371/';
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
        console.log('keks', this.ecflct);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }
  //public http: personList_HttpService;

  constructor(http: HttpClient, private router: Router, private _route: ActivatedRoute, @Inject('BASE_URL') baseUrl: string) {
    this.http = new attedanceTable_HttpService(http);
    this.baseUrl = baseUrl;
    this.selectedGroup = { idGroup: null, GroupName: '', Specialty: '' }
  }

  ngOnInit() {
    let IdECFLCT = this._route.snapshot.paramMap.get('IdECFLCT');
    let IDselectedGroup = this._route.snapshot.paramMap.get('IdselectedGroup');
    this.selectedGroup.idGroup = Number(IDselectedGroup);
    //const id = Number(this.route.snapshot);
    this.http.getAttedanceForLecturerClasses(IdECFLCT, this.selectedGroup.idGroup)
      .subscribe(result => {
        this.ecflct = result;

        this.ecflct.SubjectName = result.SubjectName;

        this.ecflct.Groups = result.Groups;
        this.ecflct.Students = result.Students;
        this.ecflct.IdECFLCT = result.IdECFLCT;
        this.ecflct.SelectedGroup = result.SelectedGroup;
        console.log('keks', this.ecflct.Groups);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
    );
    window.print();

  }


}

interface GroupAttedanceTable {
  idGroup: number,
  GroupName: string,
  Specialty: string
}
export interface ExactClassForLecturerClassTable {
  IdECFLCT: number;
  Lecturer: Lecturer2;
  LecturerFIO: string;
  ExactClasses: ExactClass[];
  Groups: GroupAttedanceTable[];
  Students: StudentTable[];
  SubjectName: string;
  Date: string;
  IdSFG: number;
  SelectedGroup: number;
}
interface StudentTable {
  IdStudent: number,
  PersonFIO: string,
  Balls: number,
  Attedanced: AttedancedVMType[]
}
interface Lecturer2 {
  IdLecturer: number,
  PersonFIO: string

}

interface ExactClass {
  IdClass: number,
  DateExactClass: string,
  numberClass: number,
  Theme: string,
  ThemeShort: string
  //Group: GroupAttedanceTable
}
interface AttedancedVMType {
  Type: string,
  attedanced: string,
  Ball: string,
  BallHW: string
}
