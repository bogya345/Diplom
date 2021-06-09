import { Component, OnInit, Inject } from '@angular/core';

import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-attedanceforpdf',
  templateUrl: './attedanceforpdf.component.html',
  styleUrls: ['./attedanceforpdf.component.css']
})
export class AttedanceforpdfComponent implements OnInit {
  //public http: attedanceTable_HttpService;
  public baseUrl: string;
  public Url = 'https://localhost:44371/';
  public ecflct: ExactClassForLecturerClassTable;
  public selectedGroup: GroupAttedanceTable;
  public now: Date;
  getAttedanceForLecturerClasses(ID_reff, group_id): Observable<ExactClassForLecturerClassTable> {
    return this.http.get<ExactClassForLecturerClassTable>(`attedance/GetAttedanceTable/${ID_reff}/${group_id}/true`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  constructor(private http: HttpClient, private router: Router, private _route: ActivatedRoute, @Inject('BASE_URL') baseUrl: string) {

    this.baseUrl = baseUrl;
    this.selectedGroup = { idGroup: null, GroupName: '', Specialty: '' }
  }

  ngOnInit() {
    let IdECFLCT = this._route.snapshot.paramMap.get('IdECFLCT');
    let IDselectedGroup = this._route.snapshot.paramMap.get('IdselectedGroup');
    this.selectedGroup.idGroup = Number(IDselectedGroup);
    //const id = Number(this.route.snapshot);
    this.getAttedanceForLecturerClasses(IdECFLCT, this.selectedGroup.idGroup)
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
  Misses: number,
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
