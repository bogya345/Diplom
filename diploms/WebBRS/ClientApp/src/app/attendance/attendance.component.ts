import { Component, OnInit, Inject } from '@angular/core';

import { attedance_HttpService } from './http.serviceAttedance';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-attendance',
  templateUrl: './attendance.component.html',
  styleUrls: ['./attendance.component.css']
})
export class AttendanceComponent implements OnInit {

  public http: attedance_HttpService;
  public baseUrl: string;
  public ecflct: ExactClassForLecturerClass;
  public selectedGroup: GroupVM;
  public now: Date;
  public ta: string;
  public cw: ClassWork;
  selectChangeHandler(event: any) {
    //update the ui
    this.ecflct.SelectedGroup = event.target.value;
    console.log(this.selectedGroup.idGroup);
    this.http.getAttedanceForLecturerClass(this.ecflct.IdECFLCT, this.ecflct.IdClass, this.ecflct.SelectedGroup)
      .subscribe(result => {
        this.ecflct = result;

        //this.ecflct.SubjectName = result.SubjectName;

        //this.ecflct.Groups = result.Groups;
        //this.ecflct.Students = result.Students;
        //this.ecflct.IdClass = result.IdClass;
        this.ecflct.SelectedGroup = result.SelectedGroup;
        console.log('keks', this.ecflct);

        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }
  selectChangeHandler2(event: any) {
    //update the ui
    this.ta = event.target.value;
    let i = 0;
    let IdAtt = '';
    let IdTA = '';
    while (this.ta[i] != '/') {
      IdAtt = IdAtt + this.ta[i];
      i++;
      // code block to be executed
    };
    i++;
    while (this.ta.length > i) {
      IdTA = IdTA + this.ta[i];
      i++;
      // code block to be executed
    };
    //console.log(IdAtt);

    this.ecflct.Students[this.ecflct.Students.findIndex(st => st.IdAttedance == IdAtt as unknown as number)].AttedanceTypeSelected = Number(IdTA);

  }
  selectChangeHandler3(event: any) {
    //update the ui
    this.ta = event.target.value;
    let i = 0;
    let IdAtt = event.target.id;
    let Ball = event.target.value;
    //let IdTA = '';
    console.log(event.target.id);
    this.ecflct.Students[this.ecflct.Students.findIndex(st => st.IdAttedance == IdAtt as number)].Ball = Number(Ball);
    console.log(this.ecflct);
  }
  selectChangeHandler4(event: any) {

    this.cw.MaxBall = Number(event.target.value);
    console.log(event.target.value);
  }
  selectChangeHandler5(event: any) {
    //update the ui
    this.cw.DatePass = event.target.value;
    console.log(this.cw.DatePass);
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
  selectChangeHandler6(event: any) {

    this.cw.IdWT = Number(event.target.value);
    console.log(event.target.value);
  }
  postData(event: any) {

    return this.http.updateAtt(this.ecflct)
      .subscribe(result => {
        console.log(result);
      });
  }
  postDataCW(event: any) {
    console.log("Дз 1", this.cw);
    return this.http.updateCW(this.cw)
      .subscribe(result => {
        console.log(result);
      });
  }
  doTextareaValueChange(ev) {
    try {
      this.cw.TextWork = ev.target.value;
      console.info(this.cw.TextWork);
    } catch (e) {
      console.info('could not set textarea-value');
    }
  }
  constructor(http: HttpClient, private router: Router, private _route: ActivatedRoute, @Inject('BASE_URL') baseUrl: string) {
    this.http = new attedance_HttpService(http);
    this.baseUrl = baseUrl;
    this.selectedGroup = { idGroup: null, GroupName: '' }
  }
  ngOnInit() {
    let IdClass = this._route.snapshot.paramMap.get('IdClass');
    let IdECFLCT = this._route.snapshot.paramMap.get('IdECFLCT');
    let IdselectedGroup = this._route.snapshot.paramMap.get('IdselectedGroup');

    //const id = Number(this.route.snapshot);
    this.http.getAttedanceForLecturerClass(IdECFLCT, IdClass, IdselectedGroup)
      .subscribe(result => {
        this.ecflct = result;
        this.ecflct.SelectedGroup = result.SelectedGroup;
        console.log('keks', this.ecflct);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
    this.http.getClassWorkExactClass(IdClass)
      .subscribe(result => {
        this.cw = result;
        this.cw.IdWT = result.IdWT;
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
        this.http.getClassWorkTypes(this.cw.IdWT)
          .subscribe(result => {
            this.cw.WorkTypes = result;
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
            console.log('result/constructorWT', this.cw.WorkTypes);

          }, error => {
            console.log('error/constructor2', error);
          }
          );
        console.log('result/constructor2', this.cw);

      }, error => {
        console.log('error/constructor2', error);
      }
    );

  }

}

interface ClassWork {
  IdClassWork: number,
  IdClasss: number,
  TextWork: string,
  FilePathWork: string,
  MaxBall: number,
  DatePass: Date,
  IdWT: number,
  WorkTypes: WorkType[]
}
interface WorkType {
  IdWT: number,
  WorkTypeName: string,
  ShortWorkTypeName: string

}
interface GroupVM {
  idGroup: number,
  GroupName: string
  //Specialty: string
  //Students: StudentEXC[]
}
interface ExactClassForLecturerClass {
  IdClass: number,
  IdECFLCT: number,
  Lecturer: Lecturer,
  Students: StudentEXC[],
  Groups: GroupVM[],
  SelectedGroup: number,
  SubjectName: string
  DateTime: string
}
class TypeAttedanceVM {
  IdTA: number;
  TAName: string;
  TAShortName: string;
  IdAtt: number;
}
interface StudentEXC {
  IdAttedance: number,
  IdStudent: number,
  PersonFIO: string,
  AttedanceTypeSelected: number,
  Attedanced: TypeAttedanceVM[],
  Ball: number,
  HW: HomeWorkStudent
}
interface HomeWorkStudent {
  IdHWS: number,
  ShortTextHW: string,
  StringFilePath: string
}
interface Lecturer {
  IdLecturer: number,
  PersonFIO: string

}

interface ExactClass {
  IdClass: number,
  DateExactClass: string,
  //numberClass: number
  //Group: Group
}

